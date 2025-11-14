using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository repository, IUnitOfWork unitOfWork) : IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment(command);
        await repository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }

    public async Task<Payment?> Handle(UpdatePaymentCommand command)
    {
        var existing = await repository.FindByIdAsync(command.Id);
        if (existing == null)
            throw new ArgumentException("Payment not found");

        try
        {
            existing.Apply(command);
            repository.Update(existing);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to update payment {command.Id}", e);
        }

        return existing;
    }
    
}