// Domain/Model/Aggregates/EfficiencyMetrics.cs
namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class EfficiencyMetrics
{
    public long Id { get; set; }
    public int Score { get; set; }
    public int WaterSaved { get; set; }
    public decimal CostSaved { get; set; }  // <-- decimal

    public long ReportSummaryId { get; set; }
    public ReportSummary? ReportSummary { get; set; }
}