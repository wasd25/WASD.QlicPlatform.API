namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record CreateBillingSettingsResource(
    int Id,
    bool Autopay,
    bool EmailNotifications,
    string BillingCycle,
    int PreferredBillingDay);