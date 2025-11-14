using WASD.QLicPlatform.API.UsageManagement.Domain.Services;

namespace WASD.QLicPlatform.API.UsageManagement.Infrastructure.Services;

/// <summary>
/// Implementación concreta del servicio de análisis de uso.
/// </summary>
public class UsageAnalysisService : IUsageAnalysisService
{
    public double CalculateAverageUsage(IEnumerable<int> usageValues)
    {
        if (!usageValues.Any()) return 0;
        return usageValues.Average();
    }

    public int PredictNextUsage(IEnumerable<int> usageValues)
    {
        if (!usageValues.Any()) return 0;

        var last = usageValues.Last();
        var avg = usageValues.Average();
        return last + (int)Math.Round(avg);
    }
}