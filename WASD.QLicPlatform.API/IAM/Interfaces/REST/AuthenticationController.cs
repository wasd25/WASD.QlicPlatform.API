using Cortex.Mediator;
using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.IAM.Application.Commands.LoginUser;
using WASD.QLicPlatform.API.IAM.Application.Commands.RegisterUser;
using WASD.QLicPlatform.API.IAM.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserResource resource)
    {
        var command = new RegisterUserCommand(
            resource.Username,
            resource.Email,
            resource.Password,
            resource.ConfirmPassword
        );

        try
        {
            await _mediator.SendCommandAsync(command);
            return Ok(new { message = "User registered successfully" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception) // Removemos la variable 'ex' no usada
        {
            return StatusCode(500, new { message = "An error occurred while registering user" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserResource resource)
    {
        var command = new LoginUserCommand(
            resource.UsernameOrEmail,
            resource.Password
        );

        try
        {
            var token = await _mediator.SendCommandAsync<LoginUserCommand, string>(command);
            return Ok(new { token = token, message = "Login successful" });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (Exception) // Removemos la variable 'ex' no usada
        {
            return StatusCode(500, new { message = "An error occurred while logging in" });
        }
    }
}