namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class ReportSummary
{
    public long Id { get; set; }
    public string Type { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Period { get; set; } = null!;
    public string Resource { get; set; }


    public List<UsageTrend>? UsageTrends { get; set; }
    public List<CostBreakdown>? CostBreakdown { get; set; }
    public EfficiencyMetrics? EfficiencyMetrics { get; set; }
}