using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Configuration;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.ToTable("payment_methods");
        
        builder.HasKey(pm => pm.Id);
        
        builder.Property(pm => pm.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd()
            .UseMySqlIdentityColumn();
        
        builder.Property(pm => pm.Type)
            .HasColumnName("type")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(pm => pm.Details)
            .HasColumnName("details")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(pm => pm.IsDefault)
            .HasColumnName("is_default")
            .IsRequired()
            .HasDefaultValue(false);
    }
}

