namespace WASD.QLicPlatform.API.Profiles.Interfaces.REST.Resources;

public record UpdateProfileResource(
    string FirstName,
    string LastName,
    string Email,
    string Street,
    string Number,
    string City,
    string PostalCode,
    string Country,
    string AvatarUrl,
    int Age,
    string Phone
);