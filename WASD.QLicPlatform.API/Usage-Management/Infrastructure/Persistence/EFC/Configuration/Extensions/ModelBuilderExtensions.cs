using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyUsageManagement(this ModelBuilder builder)
    {
        // usage Summary Context
        builder.Entity<UsageSummary>().Property(u => u.Current).IsRequired();
        builder.Entity<UsageSummary>().Property(u => u.DailyLimit).IsRequired();
        builder.Entity<UsageSummary>().Property(u => u.MonthlyTotal).IsRequired();
        
        // Usage Events Context
        builder.Entity<UsageEvents>().HasKey(u => u.Id);
        builder.Entity<UsageEvents>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UsageEvents>().Property(u => u.Time).IsRequired();
        builder.Entity<UsageEvents>().Property(u => u.Amount).IsRequired();
        builder.Entity<UsageEvents>().Property(u => u.Source).IsRequired();
    }
}