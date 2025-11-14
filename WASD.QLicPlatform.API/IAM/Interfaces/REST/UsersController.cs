using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.IAM.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.ListAsync();
        var resources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
            return NotFound(new { message = "User not found" });

        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(resource);
    }
}