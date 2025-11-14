using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Infrastructure.Persistence.EFC.Configurations;

public class UsageSummaryConfiguration : IEntityTypeConfiguration<UsageSummary>
{
    public void Configure(EntityTypeBuilder<UsageSummary> builder)
    {
        builder.ToTable("usage_summaries");

        builder.HasKey(us => us.Id);

        builder.Property(us => us.Current)
            .IsRequired();

        builder.Property(us => us.DailyLimit)
            .IsRequired();

        builder.Property(us => us.MonthlyTotal)
            .IsRequired();
    }
}