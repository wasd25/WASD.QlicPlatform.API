namespace WASD.QLicPlatform.API.UsageManagement.Domain.Models;

public class UsageSummary
{
    public Guid Id { get; private set; }
    public int Current { get; private set; }
    public int DailyLimit { get; private set; }
    public int MonthlyTotal { get; private set; }

    public UsageSummary(int current, int dailyLimit, int monthlyTotal)
    {
        Id = Guid.NewGuid();
        Current = current;
        DailyLimit = dailyLimit;
        MonthlyTotal = monthlyTotal;
    }

    public void Update(int current, int dailyLimit, int monthlyTotal)
    {
        Current = current;
        DailyLimit = dailyLimit;
        MonthlyTotal = monthlyTotal;
    }
}