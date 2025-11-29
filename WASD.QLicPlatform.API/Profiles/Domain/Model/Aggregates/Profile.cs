using WASD.QLicPlatform.API.Profiles.Domain.Model.ValueObjects;
using WASD.QLicPlatform.API.Profiles.Domain.Model.Commands;
// NOTA: Quitamos los usings de auditoría de aquí porque están en el otro archivo

namespace WASD.QLicPlatform.API.Profiles.Domain.Model.Aggregates;

/// <summary>
///     Profile Aggregate Root (Parte Principal)
/// </summary>
public partial class Profile
{
    // Constructor vacío (necesario para EF Core)
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
        AvatarUrl = string.Empty;
        Phone = string.Empty;
    }

    // Constructor completo
    public Profile(string firstName, string lastName, string email, 
        string street, string number, string city,
        string postalCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
        AvatarUrl = string.Empty;
        Phone = string.Empty;
        Age = 0;
    }

    // Constructor desde Comando
    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
        AvatarUrl = string.Empty;
        Phone = string.Empty;
        Age = 0;
    }

    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }

    // --- NUEVOS CAMPOS ---
    public string AvatarUrl { get; private set; }
    public int Age { get; private set; }
    public string Phone { get; private set; }

    // Propiedades computadas (útiles para lectura rápida)
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;

    // --- IMPORTANTE: AQUÍ ELIMINÉ CreatedDate y UpdatedDate PORQUE YA ESTÁN EN ProfileAudit.cs ---

    // --- MÉTODO PARA ACTUALIZAR ---
    public void Update(string firstName, string lastName, string email, 
                       string street, string number, string city, string postalCode, string country, 
                       string avatarUrl, int age, string phone)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, number, city, postalCode, country);
        
        AvatarUrl = avatarUrl;
        Age = age;
        Phone = phone;
        
        // No tocamos UpdatedDate aquí manualmente, dejamos que EF Core o el interceptor lo manejen
        // si tu configuración lo requiere explícitamente, descomenta la siguiente línea:
        // UpdatedDate = DateTimeOffset.UtcNow; 
    }
}