using Cortex.Mediator;
using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.Profile.Application.Commands.ChangePassword;
using WASD.QLicPlatform.API.Profile.Application.Commands.UpdateProfile;
using WASD.QLicPlatform.API.Profile.Domain.Repositories;
using WASD.QLicPlatform.API.Profile.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Profile.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Profile.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class UserProfilesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserProfileRepository _profileRepository;

    public UserProfilesController(IMediator mediator, IUserProfileRepository profileRepository)
    {
        _mediator = mediator;
        _profileRepository = profileRepository;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserProfile(int userId)
    {
        var profile = await _profileRepository.FindByUserIdAsync(userId);
        if (profile == null)
            return NotFound(new { message = "Profile not found" });

        var resource = UserProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(resource);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateProfile(int userId, [FromBody] UpdateProfileResource resource)
    {
        var command = new UpdateProfileCommand(
            userId,
            resource.FirstName,
            resource.LastName,
            resource.Age,
            resource.Phone,
            resource.Address
        );

        try
        {
            await _mediator.SendCommandAsync(command);
            return Ok(new { message = "Profile updated successfully" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "An error occurred while updating profile" });
        }
    }

    [HttpPost("{userId}/change-password")]
    public async Task<IActionResult> ChangePassword(int userId, [FromBody] ChangePasswordResource resource)
    {
        var command = new ChangePasswordCommand(
            userId,
            resource.CurrentPassword,
            resource.NewPassword,
            resource.ConfirmPassword
        );

        try
        {
            await _mediator.SendCommandAsync(command);
            return Ok(new { message = "Password changed successfully" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { message = "An error occurred while changing password" });
        }
    }
}