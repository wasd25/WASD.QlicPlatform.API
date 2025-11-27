using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Configuration;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions");
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseMySqlIdentityColumn();
        
        builder.Property(s => s.Plan)
            .HasColumnName("plan")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(s => s.Price)
            .HasColumnName("price")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(s => s.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();
    }
}

