namespace WASD.QLicPlatform.API.UsageManagement.Application.DTOs;

public class UsageSummaryDto
{
    public int Current { get; set; }
    public int DailyLimit { get; set; }
    public int MonthlyTotal { get; set; }
}