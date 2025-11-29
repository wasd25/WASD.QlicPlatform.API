// Interfaces/REST/Resources/ReportSummaryResource.cs
namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class ReportSummaryResource
{
    public long Id { get; set; }
    public string Type { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Period { get; set; } = default!;
    public string Resource { get; set; } = default!;

    public EfficiencyMetricsDto? EfficiencyMetrics { get; set; }
    public List<UsageTrendDto>? UsageTrends { get; set; }
    public List<CostBreakdownDto>? CostBreakdown { get; set; }
}