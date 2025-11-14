using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Infrastructure.Persistence.EFC.Configurations;

public class UsageEventConfiguration : IEntityTypeConfiguration<UsageEvent>
{
    public void Configure(EntityTypeBuilder<UsageEvent> builder)
    {
        builder.ToTable("usage_events");

        builder.HasKey(ue => ue.Id);

        builder.Property(ue => ue.Time)
            .IsRequired();

        builder.Property(ue => ue.Amount)
            .IsRequired();

        builder.Property(ue => ue.Source)
            .HasMaxLength(100)
            .IsRequired();
    }
}