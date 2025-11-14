namespace WASD.QLicPlatform.API.IAM.Application.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string plainPassword, string hashedPassword);
}