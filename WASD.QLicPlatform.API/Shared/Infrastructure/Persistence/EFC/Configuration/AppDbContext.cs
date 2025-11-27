using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Alerts.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Anomalies.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Profiles.Infrastructure.Persistence.EFC.Configuration.Extensions;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context for the Learning Center Platform
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Anomaly> Anomalies { get; set; }

    public DbSet<Report> Reports { get; set; }
    
    public DbSet<Payment> Payments { get; set; }
    
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    public DbSet<BillingSetting> BillingSettings { get; set; }
        
    public DbSet<ReportSummary> ReportSummaries { get; set; }
    public DbSet<UsageTrend> ReportSummaryUsageTrends { get; set; }
    public DbSet<CostBreakdown> ReportSummaryCostBreakdown { get; set; }
    public DbSet<EfficiencyMetrics> ReportSummaryEfficiencyMetrics { get; set; }

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

        // IAM
        builder.ApplyIamConfiguration();
        
        // Profiles
        builder.ApplyProfilesConfiguration();

        // Anomalies
        builder.ApplyConfiguration(new AnomalyConfiguration());

        // Alerts
        builder.ApplyAlertsConfiguration();

        // Usage Management
        builder.ApplyUsageSummaryConfiguration();
        builder.ApplyUsageEventsConfiguration();

        // Reports
        builder.ApplyReportsConfiguration();
        builder.ApplyReportSummariesConfiguration();
        
        // Payments
        builder.ApplyPaymentsConfiguration();
    }
}
