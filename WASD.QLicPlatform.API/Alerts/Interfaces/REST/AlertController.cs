using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Queries;
using WASD.QLicPlatform.API.Alerts.Domain.Services;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Alert operations using instruments or sensors")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Alerts")]
public class AlertController (IAlertCommandService alertCommandService, IAlertQueryService alertQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a new Alert",
        Description = "Creates a new Alert",
        OperationId = "CreateAlert")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Alert Was Created", typeof(AlertResource))]
    public async Task<ActionResult> CreateAlert([FromBody] CreateAlertResource resource)
    {
        var createAlertCommand = CreateAlertCommandFromResourceAssembler.ToCommandFromResource(resource);

        var result = await alertCommandService.Handle(createAlertCommand);

        if (result == null)
            return BadRequest();

        return CreatedAtAction(nameof(GetAlertById), new { id = result.Id },AlertResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets an Alert by Id",
        Description = "Gets an Alert by Id",
        OperationId = "GetAlertById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Alert Was Found", typeof(AlertResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    public async Task<ActionResult> GetAlertById([FromRoute] GetAlertByIdQuery query)
    {
        var getOrderByIdQuery = new GetAlertByIdQuery(query.Id);
        
        var result = await alertQueryService.Handle(getOrderByIdQuery);

        if (result == null)
            return NotFound();

        var alertResource = AlertResourceFromEntityAssembler.ToResourceFromEntity(result);
        
        return Ok(alertResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all Alerts",
        Description = "Gets all Alerts",
        OperationId = "GetAllAlerts")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Alerts Were Found", typeof(IEnumerable<AlertResource>))]
    public async Task<IActionResult> GetAllAlerts()
    {
        var getAllAlertsQuery = new GetAllAlertsQuery();
        var alerts = await alertQueryService.Handle(getAllAlertsQuery);
        var result = alerts.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity).ToList();

        return Ok(result);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Updates an Alert",
        Description = "Updates an Alert",
        OperationId = "UpdatesAlert")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Alert Was Updated", typeof(AlertResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid Data")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Alert Not Found")]
    public async Task<ActionResult> UpdateAlert([FromRoute] UpdateAlertCommand resource)
    {
        if (resource.AlertId <= 0)
        {
            return BadRequest("Invalid Alert Id");
        }

        var updateAlertCommand = new UpdateAlertCommand(resource.AlertId, resource.AlertType, resource.Title,
            resource.Message, resource.Timestamp);
        var result = await alertCommandService.Handle(updateAlertCommand);

        if (result == null)
        {
            return NotFound("The Alert Was Not Found");
        }
        
        return Ok(AlertResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Deletes an Alert by Id",
        Description = "Deletes an Alert with the given Id",
        OperationId = "DeleteAlert")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "The Alert Was Deleted", typeof(AlertResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Alert Not Found")]
    public async Task<ActionResult> DeleteAlert(int id)
    {
        var resource = new DeleteAlertResource(id);
        
        var deleteAlertCommand = DeleteAlertCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        await alertCommandService.Handle(deleteAlertCommand);
        
        return NoContent();
    }
    
}