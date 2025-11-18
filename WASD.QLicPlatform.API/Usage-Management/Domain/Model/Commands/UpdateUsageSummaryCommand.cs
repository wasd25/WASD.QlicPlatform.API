namespace WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

public record UpdateUsageSummaryCommand(int Current, int DailyLimit, int MonthlyTotal);