using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates; 

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReportsConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ReportsContextConfiguration());
    }

    public static void ApplyReportSummariesConfiguration(this ModelBuilder builder)
    {
        var cfg = new ReportSummariesContextConfiguration();

        builder.ApplyConfiguration<ReportSummary>(cfg);
        builder.ApplyConfiguration<UsageTrend>(cfg);
        builder.ApplyConfiguration<CostBreakdown>(cfg);
        builder.ApplyConfiguration<EfficiencyMetrics>(cfg);
    }
}