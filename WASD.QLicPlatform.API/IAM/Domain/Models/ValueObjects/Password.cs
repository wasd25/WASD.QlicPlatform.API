namespace WASD.QLicPlatform.API.IAM.Domain.Models.ValueObjects;

public record Password
{
    public string Hash { get; }

    public Password(string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
            throw new ArgumentException("Password hash cannot be empty");
            
        if (hash.Length < 8) // Validación básica
            throw new ArgumentException("Password hash too short");
            
        Hash = hash;
    }

    public override string ToString() => "[HIDDEN]";
    
    public static implicit operator string(Password password) => password.Hash;
}