// Domain/Model/Aggregates/CostBreakdown.cs
namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class CostBreakdown
{
    public long Id { get; set; }
    public string Category { get; set; } = default!;
    public decimal Cost { get; set; }  // <-- decimal

    public long ReportSummaryId { get; set; }
    public ReportSummary? ReportSummary { get; set; }
}