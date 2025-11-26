using WASD.QLicPlatform.API.Profiles.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Profiles.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.Profiles.Domain.Repositories;
using WASD.QLicPlatform.API.Profiles.Domain.Services;
using WASD.QLicPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddProfilesContextServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
        builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
    }
}