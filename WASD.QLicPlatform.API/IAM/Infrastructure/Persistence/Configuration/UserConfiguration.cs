using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.IAM.Domain.Models;

namespace WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserAggregate>
{
    public void Configure(EntityTypeBuilder<UserAggregate> builder)
    {
        builder.ToTable("iam_users");
        
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Username)
            .HasMaxLength(50)
            .IsRequired();
            
        builder.Property(u => u.Email)
            .HasMaxLength(250)
            .IsRequired();
            
        builder.Property(u => u.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();
            
        builder.Property(u => u.Status)
            .IsRequired()
            .HasConversion<int>();
            
        builder.Property(u => u.CreatedAt)
            .IsRequired();
            
        builder.Property(u => u.UpdatedAt)
            .IsRequired(false);
            
        builder.Property(u => u.LastLoginAt)
            .IsRequired(false);

        // Índices - se convertirán a snake_case automáticamente
        builder.HasIndex(u => u.Username)
            .IsUnique();
            
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}