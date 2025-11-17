using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Alerts.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAlertsConfiguration(this ModelBuilder builder)
    {
        // Alerts Context
        builder.Entity<Alert>().HasKey(e => e.Id);
        builder.Entity<Alert>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alert>().Property(e => e.type).IsRequired();
        builder.Entity<Alert>().Property(e => e.Title).IsRequired();
        builder.Entity<Alert>().Property(e => e.Message).IsRequired();
        builder.Entity<Alert>().Property(e => e.Timestamp).IsRequired();
    }
}