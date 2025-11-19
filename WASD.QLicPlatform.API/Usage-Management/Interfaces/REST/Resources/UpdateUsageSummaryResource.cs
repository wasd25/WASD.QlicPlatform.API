namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

public record UpdateUsageSummaryResource(int Current, int DailyLimit, int MonthlyTotal);