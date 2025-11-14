using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.UsageManagement.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.UsageManagement.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsageSummaryController : ControllerBase
{
    private readonly UsageSummaryCommandService _commandService;
    private readonly UsageSummaryQueryService _queryService;

    public UsageSummaryController(
        UsageSummaryCommandService commandService,
        UsageSummaryQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<ActionResult<UsageSummaryDto>> Get()
    {
        var summary = await _queryService.GetAsync();
        if (summary == null) return NotFound();
        return Ok(summary);
    }

    [HttpPost]
    public async Task<ActionResult<UsageSummary>> Create([FromBody] UsageSummaryDto dto)
    {
        var summary = await _commandService.CreateAsync(dto.Current, dto.DailyLimit, dto.MonthlyTotal);
        return CreatedAtAction(nameof(Get), new { id = summary.Id }, summary);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UsageSummaryDto dto)
    {
        var summary = await _queryService.GetAsync();
        if (summary == null) return NotFound();

        // Aquí deberías mapear el DTO a la entidad existente
        var entity = new UsageSummary(dto.Current, dto.DailyLimit, dto.MonthlyTotal);
        await _commandService.UpdateAsync(entity, dto.Current, dto.DailyLimit, dto.MonthlyTotal);

        return NoContent();
    }
}