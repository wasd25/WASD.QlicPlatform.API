namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class ReportSummary
{
    public long Id { get; set; }
    public string Type { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Period { get; set; } = default!;
    public string Resource { get; set; } = default!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public EfficiencyMetrics? EfficiencyMetrics { get; set; }
    public List<UsageTrend>? UsageTrends { get; set; }
    public List<CostBreakdown>? CostBreakdown { get; set; }
}
