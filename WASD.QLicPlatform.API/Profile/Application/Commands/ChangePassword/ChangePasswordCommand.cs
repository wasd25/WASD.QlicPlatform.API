using Cortex.Mediator.Commands;

namespace WASD.QLicPlatform.API.Profile.Application.Commands.ChangePassword;

public record ChangePasswordCommand(
    int UserId,
    string CurrentPassword,
    string NewPassword,
    string ConfirmPassword
) : ICommand;