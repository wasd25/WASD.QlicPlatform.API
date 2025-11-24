// WASD.QLicPlatform.API/Anomalies/Infrastructure/Persistence/EFC/Configuration/AnomalyConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Anomalies.Infrastructure.Persistence.EFC.Configuration
{
    public class AnomalyConfiguration : IEntityTypeConfiguration<Anomaly>
    {
        public void Configure(EntityTypeBuilder<Anomaly> builder)
        {
            builder.ToTable("anomalies");
            
            builder.HasKey(a => a.Id).HasName("p_k_anomalies");
            
            builder.Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder.Property(a => a.ProfileId)
                .HasColumnName("profile_id")
                .IsRequired();
            
            builder.Property(a => a.Type)
                .HasColumnName("type")
                .IsRequired();
            
            builder.Property(a => a.Severity)
                .HasColumnName("severity")
                .IsRequired();
            
            builder.Property(a => a.DetectedAt)
                .HasColumnName("detected_at")
                .IsRequired();
            
            builder.Property(a => a.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired();
            
            builder.Property(a => a.Metadata)
                .HasColumnName("metadata")
                .HasColumnType("longtext");
            
            builder.Property(a => a.Status)
                .HasColumnName("status")
                .IsRequired();
            
            builder.Property(a => a.ResolvedAt)
                .HasColumnName("resolved_at");
            
            // Indexes
            builder.HasIndex(a => a.DetectedAt)
                .HasDatabaseName("ix_anomalies_detected_at");
            
            builder.HasIndex(a => new { a.ProfileId, a.Status })
                .HasDatabaseName("ix_anomalies_profile_status");
        }
    }
}

