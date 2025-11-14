namespace WASD.QLicPlatform.API.UsageManagement.Domain.Services;

/// <summary>
/// Servicio de análisis de uso para cálculos estadísticos simples.
/// </summary>
public interface IUsageAnalysisService
{
    /// <summary>
    /// Calcula el promedio de uso a partir de una lista de valores.
    /// </summary>
    double CalculateAverageUsage(IEnumerable<int> usageValues);

    /// <summary>
    /// Predice el siguiente valor de uso basado en los datos anteriores.
    /// </summary>
    int PredictNextUsage(IEnumerable<int> usageValues);
}