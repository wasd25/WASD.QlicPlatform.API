using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        // Usar la cadena de conexión correcta
        var connectionString = "server=localhost;user=root;password=admin;database=qlic-database";
        
        optionsBuilder.UseMySQL(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}

