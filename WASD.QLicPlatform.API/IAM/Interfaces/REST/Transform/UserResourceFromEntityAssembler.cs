using WASD.QLicPlatform.API.IAM.Domain.Models;
using WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(UserAggregate user)
    {
        return new UserResource(
            user.Id,
            user.Username,
            user.Email,
            user.CreatedAt
        );
    }
    
    public static AuthenticatedUserResource ToAuthenticatedResourceFromEntity(UserAggregate user, string token)
    {
        return new AuthenticatedUserResource(
            user.Id,
            user.Username,
            user.Email,
            token
        );
    }
}