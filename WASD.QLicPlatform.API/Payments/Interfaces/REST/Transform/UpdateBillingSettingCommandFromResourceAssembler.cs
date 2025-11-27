using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class UpdateBillingSettingCommandFromResourceAssembler
{
    public static UpdateBillingSettingCommand ToCommandFromResource(int id, UpdateBillingSettingResource resource)
    {
        return new UpdateBillingSettingCommand(
            id,
            resource.Autopay,
            resource.EmailNotifications,
            resource.BillingCycle,
            resource.PreferredBillingDay
        );
    }
}

