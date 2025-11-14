using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class BillingSettingsAssemblers
{
    public static CreateBillingSettingsCommand ToCommand(this CreateBillingSettingsResource r) =>
        new(r.Id, r.Autopay, r.EmailNotifications, r.BillingCycle, r.PreferredBillingDay);

    public static UpdateBillingSettingsCommand ToCommand(this UpdateBillingSettingsResource r) =>
        new(r.Id, r.Autopay, r.EmailNotifications, r.BillingCycle, r.PreferredBillingDay);

    public static BillingSettingsResource ToResource(this BillingSettings e) =>
        new(e.Id, e.Autopay, e.EmailNotifications, e.BillingCycle, e.PreferredBillingDay, e.LastUpdate);
}