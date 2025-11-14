namespace WASD.QLicPlatform.API.IAM.Application.Services;

public interface ITokenService
{
    string GenerateToken(int userId, string username);
    bool ValidateToken(string token);
    (int userId, string username)? GetUserInfoFromToken(string token);
}