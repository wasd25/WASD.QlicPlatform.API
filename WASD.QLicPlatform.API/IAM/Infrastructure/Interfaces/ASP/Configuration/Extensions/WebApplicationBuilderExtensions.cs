using WASD.QLicPlatform.API.IAM.Application.ACL.Services;
using WASD.QLicPlatform.API.IAM.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.IAM.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.IAM.Application.OutboundServices;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.IAM.Domain.Services;
using WASD.QLicPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using WASD.QLicPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using WASD.QLicPlatform.API.IAM.Interfaces.ACL;

namespace WASD.QLicPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddIamContextServices(this WebApplicationBuilder builder)
    {
        // TokenSettings Configuration

        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

        // IAM Bounded Context Injection Configuration

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserCommandService, UserCommandService>();
        builder.Services.AddScoped<IUserQueryService, UserQueryService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IHashingService, HashingService>();
        builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
    }
}