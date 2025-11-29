namespace WASD.QLicPlatform.API.Profiles.Interfaces.REST.Resources;

public record ProfileResource(
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
    string Phone,
    // Mantenemos estos por si alguna vista de solo lectura los usa
    string FullName, 
    string FullAddress 
);