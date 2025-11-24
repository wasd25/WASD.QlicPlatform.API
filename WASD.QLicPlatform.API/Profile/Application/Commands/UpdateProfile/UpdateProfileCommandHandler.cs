using Cortex.Mediator.Commands;
using WASD.QLicPlatform.API.Profile.Domain.Models;
using WASD.QLicPlatform.API.Profile.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Profile.Application.Commands.UpdateProfile;

public class UpdateProfileCommandHandler : ICommandHandler<UpdateProfileCommand>
{
    private readonly IUserProfileRepository _profileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfileCommandHandler(
        IUserProfileRepository profileRepository,
        IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProfileCommand command, CancellationToken cancellationToken)
    {
        // Buscar perfil existente
        var profile = await _profileRepository.FindByUserIdAsync(command.UserId);
        if (profile == null)
            throw new ArgumentException("Profile not found");

        // Actualizar información personal
        profile.UpdatePersonalInfo(
            command.FirstName,
            command.LastName,
            command.Age,
            command.Phone,
            command.Address
        );

        // Guardar cambios
        _profileRepository.Update(profile);
        await _unitOfWork.CompleteAsync();
    }
}