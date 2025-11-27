using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.CommandServices;

public class BillingSettingCommandService(IBillingSettingRepository billingSettingRepository, IUnitOfWork unitOfWork) 
    : IBillingSettingCommandService
{
    public async Task<BillingSetting?> Handle(UpdateBillingSettingCommand command)
    {
        var billingSetting = await billingSettingRepository.FindByIdAsync(command.Id);
        
        if (billingSetting == null)
            return null;
        
        // Update properties
        billingSetting.Autopay = command.Autopay;
        billingSetting.EmailNotifications = command.EmailNotifications;
        billingSetting.BillingCycle = command.BillingCycle;
        billingSetting.PreferredBillingDay = command.PreferredBillingDay;
        
        // Automatically update LastUpdate timestamp
        billingSetting.LastUpdate = DateTime.UtcNow;
        
        billingSettingRepository.Update(billingSetting);
        await unitOfWork.CompleteAsync();
        
        return billingSetting;
    }
}

