namespace WASD.QLicPlatform.API.Profile.Domain.Models;

public class UserProfileAggregate
{
    public int Id { get; private set; } 
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; } 
    public int? Age { get; private set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // Constructor privado para EF Core
    private UserProfileAggregate()
    {
        // Inicializar propiedades non-nullable
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        CreatedAt = DateTime.UtcNow;
    }

    // Factory method para crear perfil cuando usuario se registra en IAM
    public static UserProfileAggregate Create(int userId, string email)
    {
        var profile = new UserProfileAggregate
        {
            Id = userId, // MISMO ID que IAM User
            FirstName = "", // Inicialmente vacío
            LastName = "", // Inicialmente vacío
            Email = email, // Email copiado de IAM (solo lectura)
            CreatedAt = DateTime.UtcNow
        };

        return profile;
    }

    // ÚNICO método de dominio necesario
    public void UpdatePersonalInfo(string firstName, string lastName, int? age, string? phone, string? address)
    {
        FirstName = firstName ?? string.Empty;
        LastName = lastName ?? string.Empty;
        Age = age;
        Phone = phone;
        Address = address;
        UpdatedAt = DateTime.UtcNow;
    }
}