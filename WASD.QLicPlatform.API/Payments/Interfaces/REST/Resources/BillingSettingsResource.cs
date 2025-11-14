namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record BillingSettingsResource(
    int Id,
    bool Autopay,
    bool EmailNotifications,
    string BillingCycle,
    int PreferredBillingDay,
    System.DateTime LastUpdate);