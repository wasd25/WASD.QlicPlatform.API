using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Profile.Domain.Models;

namespace WASD.QLicPlatform.API.Profile.Infrastructure.Persistence.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfileAggregate>
{
    public void Configure(EntityTypeBuilder<UserProfileAggregate> builder)
    {
        builder.ToTable("profile_user_profiles");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.FirstName)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(p => p.LastName)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(p => p.Email)
            .HasMaxLength(250)
            .IsRequired();
            
        builder.Property(p => p.Age)
            .IsRequired(false);
            
        builder.Property(p => p.Phone)
            .HasMaxLength(20)
            .IsRequired(false);
            
        builder.Property(p => p.Address)
            .HasMaxLength(500)
            .IsRequired(false);
            
        builder.Property(p => p.CreatedAt)
            .IsRequired();
            
        builder.Property(p => p.UpdatedAt)
            .IsRequired(false);
    }
}