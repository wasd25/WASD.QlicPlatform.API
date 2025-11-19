namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources
{
    public class CreateReportSummaryResource
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public string Period { get; set; }
        public string Resource { get; set; }

        public EfficiencyMetricsDto EfficiencyMetrics { get; set; }
        public List<UsageTrendDto> UsageTrends { get; set; }
        public List<CostBreakdownDto> CostBreakdown { get; set; }
    }
}