using WASD.QLicPlatform.API.Payments.Application.Internal.Validation;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class BillingSettingsCommandService(IBillingSettingsRepository repository, IUnitOfWork unitOfWork)
    : IBillingSettingsCommandService
{
    public async Task<BillingSettings?> Handle(CreateBillingSettingsCommand command)
    {
        if (await repository.AnyAsync())
            throw new InvalidOperationException("Billing settings already exist");

        Validate(command.BillingCycle, command.PreferredBillingDay);

        var entity = new BillingSettings(
            command.Id,
            command.Autopay,
            command.EmailNotifications,
            BillingSettingsValidator.NormalizeCycle(command.BillingCycle),
            command.PreferredBillingDay);

        await repository.AddAsync(entity);
        await unitOfWork.CompleteAsync();
        return entity;
    }

    public async Task<BillingSettings?> Handle(UpdateBillingSettingsCommand command)
    {
        var existing = await repository.FindByIdAsync(command.Id);
        if (existing == null) throw new ArgumentException("Billing settings not found");

        Validate(command.BillingCycle, command.PreferredBillingDay);

        existing.Update(
            command.Autopay,
            command.EmailNotifications,
            BillingSettingsValidator.NormalizeCycle(command.BillingCycle),
            command.PreferredBillingDay);

        repository.Update(existing);
        await unitOfWork.CompleteAsync();
        return existing;
    }

    private static void Validate(string cycle, int day)
    {
        if (!BillingSettingsValidator.IsValidCycle(cycle))
            throw new ArgumentException("billingCycle must be 'yearly' or 'monthly'");
        if (!BillingSettingsValidator.IsValidDay(day))
            throw new ArgumentException("preferredBillingDay must be between 1 and 31");
    }
}
