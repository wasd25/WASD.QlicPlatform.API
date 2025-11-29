using WASD.QLicPlatform.API.Profiles.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Profiles.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
    
    // Agregamos la firma del método Update
    Task<Profile?> Handle(UpdateProfileCommand command);
}