using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Model builder extensions for the database context
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Use snake case naming convention for the database context
    /// </summary>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToPlural().ToSnakeCase());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyName)) foreignKey.SetConstraintName(foreignKeyName.ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName)) index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
        }
    }

    /// <summary>
    ///     Configure the Anomalies entity mapping
    /// </summary>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    public static void ConfigureAnomalies(this ModelBuilder builder)
    {
        EntityTypeBuilder<Anomaly> entity = builder.Entity<Anomaly>();

        entity.ToTable("anomalies");
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Id).HasColumnName("id");
        entity.Property(a => a.ProfileId).HasColumnName("profile_id").IsRequired();
        entity.Property(a => a.Type).HasColumnName("type").IsRequired();
        entity.Property(a => a.Status).HasColumnName("status").IsRequired();
        entity.Property(a => a.Severity).HasColumnName("severity").IsRequired();
        entity.Property(a => a.DetectedAt).HasColumnName("detected_at").IsRequired();
        entity.Property(a => a.ResolvedAt).HasColumnName("resolved_at");
        entity.Property(a => a.Description).HasColumnName("description").HasMaxLength(500);
        entity.Property(a => a.Metadata).HasColumnName("metadata").HasColumnType("nvarchar(max)");

        // Índices útiles para filtros y tendencias
        entity.HasIndex(a => a.DetectedAt).HasDatabaseName("ix_anomalies_detected_at");
        entity.HasIndex(a => new { a.ProfileId, a.Status }).HasDatabaseName("ix_anomalies_profile_status");
    }
}
