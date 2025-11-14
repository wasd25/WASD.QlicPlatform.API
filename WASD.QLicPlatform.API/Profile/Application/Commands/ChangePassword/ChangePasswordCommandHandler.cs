using Cortex.Mediator.Commands;
using WASD.QLicPlatform.API.IAM.Application.Services;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Profile.Application.Commands.ChangePassword;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
{
    private readonly IUserRepository _iamUserRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _iamUnitOfWork;

    public ChangePasswordCommandHandler(
        IUserRepository iamUserRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork iamUnitOfWork)
    {
        _iamUserRepository = iamUserRepository;
        _passwordHasher = passwordHasher;
        _iamUnitOfWork = iamUnitOfWork;
    }

    public async Task Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        // Validaciones
        if (command.NewPassword != command.ConfirmPassword)
            throw new ArgumentException("New password and confirmation do not match");

        // Buscar usuario en IAM
        var user = await _iamUserRepository.FindByIdAsync(command.UserId);
        if (user == null)
            throw new ArgumentException("User not found");

        // Verificar contraseña actual
        if (!_passwordHasher.VerifyPassword(command.CurrentPassword, user.PasswordHash))
            throw new UnauthorizedAccessException("Current password is incorrect");

        // Validar nueva contraseña (mínimo 8 caracteres, mayúsculas, minúsculas, números)
        if (command.NewPassword.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long");

        // Actualizar contraseña en IAM
        var newPasswordHash = _passwordHasher.HashPassword(command.NewPassword);
        user.UpdatePassword(newPasswordHash);
        _iamUserRepository.Update(user);

        // Guardar cambios en IAM
        await _iamUnitOfWork.CompleteAsync();
    }
}