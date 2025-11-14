namespace WASD.QLicPlatform.API.Profile.Interfaces.REST.Resources;

public record ChangePasswordResource(
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword
);