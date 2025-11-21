using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensionsUsageSummary
{
    public static void ApplyUsageSummaryConfiguration(this ModelBuilder builder)
    {
        // usage Summary Context
        builder.Entity<UsageSummary>().Property(u => u.Current).IsRequired();
        builder.Entity<UsageSummary>().Property(u => u.DailyLimit).IsRequired();
        builder.Entity<UsageSummary>().Property(u => u.MonthlyTotal).IsRequired();
    }
}