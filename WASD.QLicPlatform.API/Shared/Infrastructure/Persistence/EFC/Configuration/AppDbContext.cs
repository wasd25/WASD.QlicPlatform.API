using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration.Extensions; // 👈 agregado

namespace WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    ///     On configuring the database context
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    /// <summary>
    ///     On creating the database model
    /// </summary>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
        
        // Configuración de Reports
        builder.ApplyReportsConfiguration();
        
        // Configuración de ReportSummaries
        builder.ApplyReportSummariesConfiguration();
    }

    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportSummary> ReportSummaries { get; set; }
    public DbSet<UsageTrend> ReportSummaryUsageTrends { get; set; }
    public DbSet<CostBreakdown> ReportSummaryCostBreakdown { get; set; }
    public DbSet<EfficiencyMetrics> ReportSummaryEfficiencyMetrics { get; set; }
}