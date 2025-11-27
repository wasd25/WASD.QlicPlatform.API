using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Configuration;

public class BillingSettingConfiguration : IEntityTypeConfiguration<BillingSetting>
{
    public void Configure(EntityTypeBuilder<BillingSetting> builder)
    {
        builder.ToTable("billing_settings");
        
        builder.HasKey(bs => bs.Id);
        
        builder.Property(bs => bs.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseMySqlIdentityColumn();
        
        builder.Property(bs => bs.Autopay)
            .HasColumnName("autopay")
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(bs => bs.EmailNotifications)
            .HasColumnName("email_notifications")
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(bs => bs.BillingCycle)
            .HasColumnName("billing_cycle")
            .HasMaxLength(20)
            .IsRequired()
            .HasDefaultValue("monthly");
        
        builder.Property(bs => bs.PreferredBillingDay)
            .HasColumnName("preferred_billing_day")
            .IsRequired()
            .HasDefaultValue(1);
        
        builder.Property(bs => bs.LastUpdate)
            .HasColumnName("last_update")
            .IsRequired();
        
        builder.Property(bs => bs.UserId)
            .HasColumnName("user_id")
            .IsRequired(false);
    }
}

