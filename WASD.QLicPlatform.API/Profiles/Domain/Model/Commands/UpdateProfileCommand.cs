namespace WASD.QLicPlatform.API.Profiles.Domain.Model.Commands;

public record UpdateProfileCommand(
    int Id,
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