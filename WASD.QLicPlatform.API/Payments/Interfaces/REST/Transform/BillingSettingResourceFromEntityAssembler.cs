using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class BillingSettingResourceFromEntityAssembler
{
    public static BillingSettingResource ToResourceFromEntity(BillingSetting entity)
    {
        return new BillingSettingResource(
            entity.Id,
            entity.Autopay,
            entity.EmailNotifications,
            entity.BillingCycle,
            entity.PreferredBillingDay,
            entity.LastUpdate
        );
    }
}

