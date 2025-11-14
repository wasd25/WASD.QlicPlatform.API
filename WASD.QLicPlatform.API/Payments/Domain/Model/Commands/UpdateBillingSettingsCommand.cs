namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdateBillingSettingsCommand(int Id, bool Autopay, bool EmailNotifications, string BillingCycle, int PreferredBillingDay);