namespace WASD.QLicPlatform.API.Profile.Interfaces.REST.Resources;

public record UserProfileResource(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    int? Age,
    string? Phone,
    string? Address,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);