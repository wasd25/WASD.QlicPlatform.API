using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST;

[ApiController]
[Route("api/vq/[controller]")]
[SwaggerTag("Usage Summary by consumption on the gallons")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Usage Summary")]
public class UsageSummaryController (IUsageSummaryCommandService  usageSummaryCommandService, IUsageSummaryQueryService  usageSummaryQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all summaries",
        Description = "Gets all summaries by consumption on the gallons",
        OperationId = "GetUsageSummary")]
    [SwaggerResponse(StatusCodes.Status200OK, "The summaries Were Found", typeof(IEnumerable<UsageSummaryResource>))]
    public async Task<IActionResult> GetUsageSummary()
    {
        var getUsageSummary = new GetUsageSummaryQuery();
        var usageSummary = await usageSummaryQueryService.Handle(getUsageSummary);
        var result = usageSummary.Select(UsageSummaryResourceFromEntityAssembler.ToResourceFromEntity).ToList();

        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Updates an Usage Summary",
        Description = "Updates an Usage Summary",
        OperationId = "UpdatesUsageSummary")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Usage Summary Was Updated", typeof(UsageSummaryResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Usage Summary Not Found")]
    public async Task<ActionResult> UpdateUsageSummary([FromRoute] int id, [FromBody] UpdateUsageSummaryResource resource)
    {
        if (id <= 0) return BadRequest("Invalid Usage Summary Id");

        var command = UpdateUsageSummaryCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await usageSummaryCommandService.Handle(command);
        if (result == null) return NotFound();
        return Ok(UsageSummaryResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}