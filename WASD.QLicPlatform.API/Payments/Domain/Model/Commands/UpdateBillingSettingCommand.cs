namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdateBillingSettingCommand(
    int Id,
    bool Autopay,
    bool EmailNotifications,
    string BillingCycle,
    int PreferredBillingDay
);

