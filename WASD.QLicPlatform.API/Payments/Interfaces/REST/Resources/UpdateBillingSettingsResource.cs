namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record UpdateBillingSettingsResource(
    int Id,
    bool Autopay,
    bool EmailNotifications,
    string BillingCycle,
    int PreferredBillingDay);