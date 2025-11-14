using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.UsageManagement.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.UsageManagement.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsageEventsController : ControllerBase
{
    private readonly UsageEventCommandService _commandService;
    private readonly UsageEventQueryService _queryService;

    public UsageEventsController(
        UsageEventCommandService commandService,
        UsageEventQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsageEventDto>>> GetAll()
    {
        var events = await _queryService.GetAllAsync();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UsageEventDto>> GetById(Guid id)
    {
        var usageEvent = await _queryService.GetByIdAsync(id);
        if (usageEvent == null) return NotFound();
        return Ok(usageEvent);
    }

    [HttpPost]
    public async Task<ActionResult<UsageEvent>> Create([FromBody] UsageEventDto dto)
    {
        // Parseamos la hora desde el string HH:mm
        var time = DateTime.ParseExact(dto.Time, "HH:mm", null);
        var usageEvent = await _commandService.RegisterAsync(time, dto.Amount, dto.Source);

        return CreatedAtAction(nameof(GetById), new { id = usageEvent.Id }, usageEvent);
    }
}