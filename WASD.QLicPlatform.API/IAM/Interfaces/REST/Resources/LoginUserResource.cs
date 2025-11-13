namespace WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

public record LoginUserResource(
    string UsernameOrEmail,
    string Password
);