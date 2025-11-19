namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class UsageTrend
{
    public long Id { get; set; }
    public string Day { get; set; } = null!;
    public int Liters { get; set; }

    public long ReportSummaryId { get; set; }
    public ReportSummary? ReportSummary { get; set; }
}