using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("The usage events for the interaction by IOT sensors")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Usage Events")]
public class UsageEventsController (IUsageEventCommandService usageEventCommandService, IUsageEventQueryService usageEventQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Usage Event",
        Description = "Creates a new Usage Event",
        OperationId = "CreateUsageEvent")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Usage Event Was Created", typeof(UsageEventsResource))]
    public async Task<ActionResult> CreateUsageEvent([FromBody] CreateUsageEventsResource resource)
    {
        var createUsageEventCommand = CreateUsageEventsCommandFromResourceAssembler.ToCommandFromResource(resource);

        var result = await usageEventCommandService.Handle(createUsageEventCommand);

        if (result == null)
            return BadRequest();

        return CreatedAtAction(nameof(GetUsageEventById), new { id = result.Id },UsageEventsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets an Usage Event by Id",
        Description = "Gets an Usage Event by Id",
        OperationId = "GetUsageEventById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Usage Event Was Found", typeof(UsageEventsResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    public async Task<ActionResult> GetUsageEventById([FromRoute] int id)
    {
        if (id <= 0) return BadRequest("Invalid Id");

        var query = new GetUsageEventByIdQuery(id);
        var result = await usageEventQueryService.Handle(query);

        if (result == null) return NotFound();

        var usageEventResource = UsageEventsResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(usageEventResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Usage Events",
        Description = "Gets all Usage Events",
        OperationId = "GetAllUsageEvents")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Usage Events Were Found", typeof(IEnumerable<UsageEventsResource>))]
    public async Task<IActionResult> GetAllUsageEvents()
    {
        var getAllAlertsQuery = new GetAllUsageEventsQuery();
        var alerts = await usageEventQueryService.Handle(getAllAlertsQuery);
        var result = alerts.Select(UsageEventsResourceFromEntityAssembler.ToResourceFromEntity).ToList();

        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Updates an Usage Event",
        Description = "Updates an Usage Event",
        OperationId = "UpdatesUsageEvent")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Usage Event Was Updated", typeof(UsageEventsResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Usage Event Not Found")]
    public async Task<ActionResult> UpdateUsageEvent([FromRoute] int id, [FromBody] UpdateUsageEventsResource resource)
    {
        if (id <= 0) return BadRequest("Invalid Usage Event Id");

        var command = UpdateUsageEventsCommandFromAssembler.ToCommandFromResource(id, resource);
        var result = await usageEventCommandService.Handle(command);
        if (result == null) return NotFound();
        return Ok(UsageEventsResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Deletes an Usage Event by Id",
        Description = "Deletes an Usage Event with the given Id",
        OperationId = "DeleteUsageEvent")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Usage Event Was Deleted", typeof(UsageEventsResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Alert Not Found")]
    public async Task<ActionResult> DeleteAlert(int id)
    {
        var resource = new DeleteUsageEventsResource(id);
        var command = DeleteusageEventsCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await usageEventCommandService.Handle(command);
        if (result == null) return NotFound("Usage Event Not Found");
        return NoContent();
    }
}