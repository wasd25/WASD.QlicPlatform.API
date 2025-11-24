namespace WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(
    int Id,
    string Username,
    string Email,
    string Token
);