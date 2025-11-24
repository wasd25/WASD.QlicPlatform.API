using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration;

public class ReportSummariesContextConfiguration :
    IEntityTypeConfiguration<ReportSummary>,
    IEntityTypeConfiguration<UsageTrend>,
    IEntityTypeConfiguration<CostBreakdown>,
    IEntityTypeConfiguration<EfficiencyMetrics>
{
    public void Configure(EntityTypeBuilder<ReportSummary> builder)
    {
        builder.ToTable("report_summaries");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Period).IsRequired().HasMaxLength(100);

        builder.HasMany(x => x.UsageTrends)
               .WithOne(x => x.ReportSummary!)
               .HasForeignKey(x => x.ReportSummaryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_usagetrend_summary"); // 👈 nombre corto

        builder.HasMany(x => x.CostBreakdown)
               .WithOne(x => x.ReportSummary!)
               .HasForeignKey(x => x.ReportSummaryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_costbreakdown_summary"); // 👈 nombre corto

        builder.HasOne(x => x.EfficiencyMetrics)
               .WithOne(x => x.ReportSummary!)
               .HasForeignKey<EfficiencyMetrics>(x => x.ReportSummaryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_efficiency_summary"); // 👈 nombre corto
    }

    public void Configure(EntityTypeBuilder<UsageTrend> builder)
    {
        builder.ToTable("report_summary_usage_trends");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Day).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Liters).IsRequired();
    }

    public void Configure(EntityTypeBuilder<CostBreakdown> builder)
    {
        builder.ToTable("report_summary_cost_breakdown");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Category).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Cost).HasColumnType("decimal(12,2)").IsRequired();

        builder.HasOne(x => x.ReportSummary)
               .WithMany(x => x.CostBreakdown)
               .HasForeignKey(x => x.ReportSummaryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_costbreakdown_summary"); // 👈 nombre corto
    }

    public void Configure(EntityTypeBuilder<EfficiencyMetrics> builder)
    {
        builder.ToTable("report_summary_efficiency_metrics");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Score).IsRequired();
        builder.Property(x => x.WaterSaved).IsRequired();
        builder.Property(x => x.CostSaved).IsRequired();

        builder.HasOne(x => x.ReportSummary)
               .WithOne(x => x.EfficiencyMetrics)
               .HasForeignKey<EfficiencyMetrics>(x => x.ReportSummaryId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("fk_efficiency_summary"); // 👈 nombre corto
    }
}
