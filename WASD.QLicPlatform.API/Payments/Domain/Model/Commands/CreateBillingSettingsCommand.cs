namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record CreateBillingSettingsCommand(int Id, bool Autopay, bool EmailNotifications, string BillingCycle, int PreferredBillingDay);