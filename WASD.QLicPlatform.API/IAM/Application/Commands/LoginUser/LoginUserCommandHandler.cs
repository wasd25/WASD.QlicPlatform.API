using Cortex.Mediator.Commands;
using WASD.QLicPlatform.API.IAM.Application.Services;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.IAM.Application.Commands.LoginUser;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        // Buscar usuario por username o email
        var user = await _userRepository.FindByUsernameOrEmailAsync(command.UsernameOrEmail);
        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        // Verificar password
        if (!_passwordHasher.VerifyPassword(command.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        // Verificar si el usuario está activo
        if (!user.IsActive())
            throw new UnauthorizedAccessException("Account is not active");

        // Actualizar último login
        user.UpdateLoginTimestamp();
        _userRepository.Update(user);
        await _unitOfWork.CompleteAsync();

        // Generar token
        return _tokenService.GenerateToken(user.Id, user.Username);
    }
}