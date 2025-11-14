namespace WASD.QLicPlatform.API.UsageManagement.Domain.Services;

public interface IUsageMonitoringService
{
    bool HasExceededDailyLimit(int current, int dailyLimit);
    bool HasExceededMonthlyTotal(int monthlyTotal, int threshold);
}