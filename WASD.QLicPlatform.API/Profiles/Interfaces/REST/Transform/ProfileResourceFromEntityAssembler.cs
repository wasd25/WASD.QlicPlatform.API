using WASD.QLicPlatform.API.Profiles.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Profiles.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.Name.FirstName,
            entity.Name.LastName,
            entity.Email.Address,
            entity.Address.Street,
            entity.Address.Number,
            entity.Address.City,
            entity.Address.PostalCode,
            entity.Address.Country,
            entity.AvatarUrl,
            entity.Age,
            entity.Phone,
            entity.FullName,     // Dato extra computado
            entity.StreetAddress // Dato extra computado
        );
    }
}