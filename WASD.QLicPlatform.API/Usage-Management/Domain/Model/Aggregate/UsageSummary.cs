using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

public partial class UsageSummary
{
    public int Current { get; private set; }
    public int DailyLimit { get; private set; }
    public int MonthlyTotal { get; private set; }

    public UsageSummary(int current, int dailyLimit, int monthlyTotal)
    {
        Current = current;
        DailyLimit = dailyLimit;
        MonthlyTotal = monthlyTotal;
    }

    public UsageSummary(UpdateUsageSummaryCommand command)
    {
        this.Current = command.Current;
        this.DailyLimit = command.DailyLimit;
        this.MonthlyTotal = command.MonthlyTotal;
    }

    public void Update(int current, int dailyLimit, int monthlyTotal)
    {
        Current = current;
        DailyLimit = dailyLimit;
        MonthlyTotal = monthlyTotal;
    }
}