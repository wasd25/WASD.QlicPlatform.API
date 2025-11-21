namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

public record UsageSummaryResource(
    long Id,
    int Current,
    int DailyLimit,
    int MonthlyTotal);