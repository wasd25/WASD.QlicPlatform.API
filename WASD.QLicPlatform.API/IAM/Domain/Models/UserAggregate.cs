using WASD.QLicPlatform.API.IAM.Domain.Models.Enums;
using WASD.QLicPlatform.API.IAM.Domain.Models.ValueObjects;

namespace WASD.QLicPlatform.API.IAM.Domain.Models;

public class UserAggregate
{
    public int Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }

    // Constructor privado para EF Core - INICIALIZAR TODAS LAS PROPIEDADES
    private UserAggregate()
    {
        // Inicializar todas las non-nullable properties
        Username = string.Empty;
        Email = string.Empty;
        PasswordHash = string.Empty;
        Status = UserStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    // Factory method para crear nuevo usuario
    public static UserAggregate Create(string username, string email, string passwordHash)
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty");
            
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty");
            
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty");

        var user = new UserAggregate
        {
            Username = username.ToLower().Trim(),
            Email = email.ToLower().Trim(),
            PasswordHash = passwordHash,
            Status = UserStatus.Active,
            CreatedAt = DateTime.UtcNow
        };

        return user;
    }

    // Métodos de dominio
    public void UpdatePassword(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new ArgumentException("Password hash cannot be empty");
            
        PasswordHash = newPasswordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLoginTimestamp()
    {
        LastLoginAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    public bool IsActive() => Status == UserStatus.Active;
}