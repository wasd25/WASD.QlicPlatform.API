using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.Reports.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Reports.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly ReportCommandService _commandService;
    private readonly ReportQueryService _queryService;

    public ReportsController(ReportCommandService commandService, ReportQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportResource resource)
    {
        try
        {
            var report = await _commandService.CreateAsync(resource.Title, resource.Description);
            var response = ReportResourceAssembler.ToResource(report);
            return Created($"/api/v1/reports/{report.Id}", response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _queryService.GetAllAsync();
        var resources = reports.Select(ReportResourceAssembler.ToResource);
        return Ok(resources);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var report = await _queryService.GetByIdAsync(id);
        if (report == null) return NotFound();
        return Ok(ReportResourceAssembler.ToResource(report));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateReportResource resource)
    {
        var report = await _commandService.UpdateAsync(id, resource.Title, resource.Description);
        if (report == null) return NotFound();
        return Ok(ReportResourceAssembler.ToResource(report));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _commandService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
