namespace WASD.QLicPlatform.API.UsageManagement.Domain.Models;

public class UsageEvent
{
    public Guid Id { get; private set; }
    public DateTime Time { get; private set; }
    public int Amount { get; private set; }
    public string Source { get; private set; } = string.Empty;

    public UsageEvent(DateTime time, int amount, string source)
    {
        Id = Guid.NewGuid();
        Time = time;
        Amount = amount;
        Source = source;
    }
}