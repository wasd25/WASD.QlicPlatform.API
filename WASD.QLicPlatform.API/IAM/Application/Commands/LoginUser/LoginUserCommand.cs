using Cortex.Mediator.Commands;

namespace WASD.QLicPlatform.API.IAM.Application.Commands.LoginUser;

public record LoginUserCommand(
    string UsernameOrEmail,
    string Password
) : ICommand<string>; // Retorna el token