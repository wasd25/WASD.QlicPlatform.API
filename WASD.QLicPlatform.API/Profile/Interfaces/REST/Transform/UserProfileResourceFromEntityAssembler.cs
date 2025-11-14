using WASD.QLicPlatform.API.Profile.Domain.Models;
using WASD.QLicPlatform.API.Profile.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Profile.Interfaces.REST.Transform;

public static class UserProfileResourceFromEntityAssembler
{
    public static UserProfileResource ToResourceFromEntity(UserProfileAggregate profile)
    {
        return new UserProfileResource(
            profile.Id,
            profile.FirstName,
            profile.LastName,
            profile.Email,
            profile.Age,
            profile.Phone,
            profile.Address,
            profile.CreatedAt,
            profile.UpdatedAt
        );
    }
}