namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;

public class BillingSettings
{
    public int Id { get; private set; } = default!;
    public bool Autopay { get; private set; }
    public bool EmailNotifications { get; private set; }
    public string BillingCycle { get; private set; } = default!;
    public int PreferredBillingDay { get; private set; }
    public DateTime LastUpdate { get; private set; }

    public BillingSettings(int id, bool autopay, bool emailNotifications, string billingCycle, int preferredBillingDay)
    {
        Id = id;
        Autopay = autopay;
        EmailNotifications = emailNotifications;
        BillingCycle = billingCycle;
        PreferredBillingDay = preferredBillingDay;
        LastUpdate = DateTime.UtcNow;
    }

    public void Update(bool autopay, bool emailNotifications, string billingCycle, int preferredBillingDay)
    {
        Autopay = autopay;
        EmailNotifications = emailNotifications;
        BillingCycle = billingCycle;
        PreferredBillingDay = preferredBillingDay;
        LastUpdate = DateTime.UtcNow;
    }
}