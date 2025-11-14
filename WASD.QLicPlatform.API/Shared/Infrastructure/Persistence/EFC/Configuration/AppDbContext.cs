using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Infrastructure.Persistence.EFC.Configurations;

using WASD.QLicPlatform.API.IAM.Domain.Models;


namespace WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    
    public DbSet<Anomaly> Anomalies { get; set; }
    
    // Agregar el DbSet para Users
    public DbSet<UserAggregate> Users { get; set; }

    /// <summary>
    ///     On configuring the database context
    /// </summary>
    /// <remarks>
    ///     This method is used to configure the database context.
    ///     It also adds the created and updated date interceptor to the database context.
    /// </remarks>
    /// <param name="builder">
    ///     The option builder for the database context
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    /// <summary>
    ///     On creating the database model
    /// </summary>
    /// <remarks>
    ///     This method is used to create the database model for the application.
    /// </remarks>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();


        // Apply UsageManagement configurations
        builder.ApplyConfiguration(new UsageSummaryConfiguration());
        builder.ApplyConfiguration(new UsageEventConfiguration());
    }

    // DbSets for UsageManagement
    public DbSet<UsageSummary> UsageSummaries { get; set; }
    public DbSet<UsageEvent> UsageEvents { get; set; }

        
        // Configuración específica de Anomalies
        builder.ConfigureAnomalies();

        // Aplicar configuración de IAM
        builder.ApplyConfiguration(new WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.Configuration.UserConfiguration());

    }

}