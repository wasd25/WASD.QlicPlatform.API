namespace WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

public record RegisterUserResource(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
);