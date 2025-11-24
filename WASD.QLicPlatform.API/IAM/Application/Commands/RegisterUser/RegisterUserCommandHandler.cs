using Cortex.Mediator.Commands;
using WASD.QLicPlatform.API.IAM.Application.Services;
using WASD.QLicPlatform.API.IAM.Domain.Models;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.IAM.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        // Validaciones de negocio
        if (command.Password != command.ConfirmPassword)
            throw new ArgumentException("Passwords do not match");

        if (await _userRepository.ExistsByUsernameAsync(command.Username))
            throw new ArgumentException("Username already exists");

        if (await _userRepository.ExistsByEmailAsync(command.Email))
            throw new ArgumentException("Email already exists");

        // Hash password
        var passwordHash = _passwordHasher.HashPassword(command.Password);

        // Crear usuario
        var user = UserAggregate.Create(command.Username, command.Email, passwordHash);

        // Guardar
        await _userRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();
    }
}