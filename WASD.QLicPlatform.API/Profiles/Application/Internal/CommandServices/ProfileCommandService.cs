using WASD.QLicPlatform.API.Profiles.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Profiles.Domain.Model.Commands;
using WASD.QLicPlatform.API.Profiles.Domain.Repositories;
using WASD.QLicPlatform.API.Profiles.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        await profileRepository.AddAsync(profile);
        await unitOfWork.CompleteAsync();
        return profile;
    }

    // --- IMPLEMENTACIÓN DEL UPDATE ---
    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.FindByIdAsync(command.Id);

        if (profile is null) return null;

        // Llamamos al método Update de la entidad
        profile.Update(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Street,
            command.Number,
            command.City,
            command.PostalCode,
            command.Country,
            command.AvatarUrl,
            command.Age,
            command.Phone
        );

        try
        {
            profileRepository.Update(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while updating the profile: {e.Message}");
            return null;
        }
    }
}