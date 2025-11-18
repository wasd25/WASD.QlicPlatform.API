using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration;

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyReportsConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ReportsContextConfiguration());
    }
}