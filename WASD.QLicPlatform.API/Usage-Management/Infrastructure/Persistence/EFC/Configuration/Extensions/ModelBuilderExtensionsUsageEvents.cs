using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensionsUsageEvents
{
    public static void ApplyUsageEventsConfiguration(this ModelBuilder builder)
    {
        // Usage Events Context
        builder.Entity<UsageEvents>().HasKey(u => u.Id);
        builder.Entity<UsageEvents>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UsageEvents>().Property(u => u.Time).IsRequired();
        builder.Entity<UsageEvents>().Property(u => u.Amount).IsRequired();
        builder.Entity<UsageEvents>().Property(u => u.Source).IsRequired();
    }
}