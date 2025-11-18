using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration;

public class ReportsContextConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("reports");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(r => r.Description)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.UpdatedAt);
    }
}