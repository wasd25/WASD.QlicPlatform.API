namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class CostBreakdown
{
    public long Id { get; set; }
    public string Category { get; set; } = null!;
    public decimal Cost { get; set; }

    public long ReportSummaryId { get; set; }
    public ReportSummary? ReportSummary { get; set; }
}