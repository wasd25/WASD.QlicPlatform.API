// Interfaces/REST/Resources/EfficiencyMetricsDto.cs
namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class EfficiencyMetricsDto
{
    public int Score { get; set; }
    public int WaterSaved { get; set; }
    public decimal CostSaved { get; set; }  // <-- decimal
}