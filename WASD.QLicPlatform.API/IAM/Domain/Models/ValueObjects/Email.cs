namespace WASD.QLicPlatform.API.IAM.Domain.Models.ValueObjects;

public record Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Email cannot be empty");
            
        // Validación básica de email
        if (!address.Contains('@') || !address.Contains('.'))
            throw new ArgumentException("Invalid email format");
            
        Address = address.ToLower().Trim();
    }

    public override string ToString() => Address;
    
    public static implicit operator string(Email email) => email.Address;
    public static implicit operator Email(string address) => new Email(address);
}