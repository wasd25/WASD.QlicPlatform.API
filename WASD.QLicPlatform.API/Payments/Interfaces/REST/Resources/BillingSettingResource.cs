namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record BillingSettingResource(
    int Id,
    bool Autopay,
    bool EmailNotifications,
    string BillingCycle,
    int PreferredBillingDay,
    DateTime LastUpdate
);

