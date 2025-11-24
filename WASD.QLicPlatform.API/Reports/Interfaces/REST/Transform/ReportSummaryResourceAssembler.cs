using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Transform
{
    public static class ReportSummaryResourceAssembler
    {
        public static ReportSummaryResource ToResource(ReportSummary entity)
        {
            return new ReportSummaryResource
            {
                Id = entity.Id,
                Type = entity.Type,
                Location = entity.Location,
                Period = entity.Period,
                Resource = entity.Resource,

                EfficiencyMetrics = entity.EfficiencyMetrics is not null
                    ? new EfficiencyMetricsDto
                    {
                        Score = entity.EfficiencyMetrics.Score,
                        WaterSaved = entity.EfficiencyMetrics.WaterSaved,
                        CostSaved = entity.EfficiencyMetrics.CostSaved
                    }
                    : null,

                UsageTrends = entity.UsageTrends?.Select(x => new UsageTrendDto
                {
                    Day = x.Day,
                    Liters = x.Liters
                }).ToList(),

                CostBreakdown = entity.CostBreakdown?.Select(x => new CostBreakdownDto
                {
                    Category = x.Category,
                    Cost = x.Cost
                }).ToList()
            };
        }

        public static List<ReportSummaryResource> ToResourceList(List<ReportSummary> entities)
        {
            return entities.Select(ToResource).ToList();
        }
    }
}