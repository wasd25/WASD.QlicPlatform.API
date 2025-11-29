// Interfaces/REST/Resources/CreateReportSummaryResource.cs
using System.ComponentModel.DataAnnotations;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class CreateReportSummaryResource
{
    [Required] public string Type { get; set; } = default!;
    [Required] public string Location { get; set; } = default!;
    [Required] public string Period { get; set; } = default!;
    [Required] public string Resource { get; set; } = default!;  // <-- nombre exacto

    public EfficiencyMetricsDto? EfficiencyMetrics { get; set; }
    public List<UsageTrendDto>? UsageTrends { get; set; }
    public List<CostBreakdownDto>? CostBreakdown { get; set; }
}