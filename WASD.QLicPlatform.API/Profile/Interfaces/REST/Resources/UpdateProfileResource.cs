namespace WASD.QLicPlatform.API.Profile.Interfaces.REST.Resources;

public record UpdateProfileResource(
    string FirstName,
    string LastName,
    int? Age,
    string? Phone,
    string? Address
);