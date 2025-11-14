using WASD.QLicPlatform.API.Payments.Application.Internal.Validation;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class PaymentMethodCommandService(IPaymentMethodRepository repository, IUnitOfWork unitOfWork) : IPaymentMethodCommandService
{
    public async Task<PaymentMethod?> Handle(CreatePaymentMethodCommand command)
    {
        Validate(command.Type, command.Details, out var cleanCard);

        var entity = new PaymentMethod(command.Id, NormalizeType(command.Type), cleanCard, command.IsDefault);

        if (entity.IsDefault)
        {
            await repository.ClearDefaultExceptAsync(entity.Id);
        }

        await repository.AddAsync(entity);
        await unitOfWork.CompleteAsync();
        return entity;
    }

    public async Task<PaymentMethod?> Handle(UpdatePaymentMethodCommand command)
    {
        var existing = await repository.FindByIdAsync(command.Id);
        if (existing == null) throw new ArgumentException("Payment method not found");

        Validate(command.Type, command.Details, out var cleanCard);

        existing.Update(NormalizeType(command.Type), cleanCard, command.IsDefault);
        if (existing.IsDefault)
        {
            await repository.ClearDefaultExceptAsync(existing.Id);
        }

        repository.Update(existing);
        await unitOfWork.CompleteAsync();
        return existing;
    }

    public async Task<PaymentMethod?> Handle(DeletePaymentMethodCommand command)
    {
        var existing = await repository.FindByIdAsync(command.Id);
        if (existing == null) throw new ArgumentException("Payment method not found");

        repository.Remove(existing);
        await unitOfWork.CompleteAsync();
        return existing;
    }

    private static void Validate(string type, string details, out string cleanCard)
    {
        if (!PaymentMethodValidator.IsSupportedType(type))
            throw new ArgumentException("Type must be 'Visa' or 'PayPal'");

        cleanCard = PaymentMethodValidator.SanitizeCard(details);
        if (!PaymentMethodValidator.IsValidCard(cleanCard))
            throw new ArgumentException("Details must be a valid card number (12-19 dígitos, Luhn)");
    }

    private static string NormalizeType(string type)
        => string.Equals(type, "PayPal", StringComparison.OrdinalIgnoreCase) ? "PayPal" : "Visa";
}
