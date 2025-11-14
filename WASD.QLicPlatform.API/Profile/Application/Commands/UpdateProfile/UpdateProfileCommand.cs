using Cortex.Mediator.Commands;

namespace WASD.QLicPlatform.API.Profile.Application.Commands.UpdateProfile;

public record UpdateProfileCommand(
    int UserId,
    string FirstName,
    string LastName,
    int? Age,
    string? Phone,
    string? Address
) : ICommand;