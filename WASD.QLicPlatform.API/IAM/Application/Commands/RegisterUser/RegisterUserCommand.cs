using Cortex.Mediator.Commands;

namespace WASD.QLicPlatform.API.IAM.Application.Commands.RegisterUser;

public record RegisterUserCommand(
    string Username,
    string Email, 
    string Password,
    string ConfirmPassword
) : ICommand;