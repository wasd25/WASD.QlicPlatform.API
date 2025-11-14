using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/billingSettings")]
[SwaggerTag("Billing Settings operations")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("BillingSettings")]
public class BillingSettingsController(IBillingSettingsCommandService commandService, IBillingSettingsQueryService queryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Crea configuración de facturación (única)", OperationId = "CreateBillingSettings")]
    [SwaggerResponse(StatusCodes.Status201Created, "Creado", typeof(BillingSettingsResource))]
    [SwaggerResponse(StatusCodes.Status409Conflict, "Ya existe")]
    public async Task<ActionResult> Create([FromBody] CreateBillingSettingsResource resource)
    {
        try
        {
            var created = await commandService.Handle(resource.ToCommand());
            return CreatedAtAction(nameof(GetSingleton), new { }, created!.ToResource());
        }
        catch (InvalidOperationException)
        {
            return Conflict("Billing settings already exist");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Obtiene la configuración única", OperationId = "GetBillingSettings")]
    [SwaggerResponse(StatusCodes.Status200OK, "Encontrado", typeof(BillingSettingsResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No existe")]
    public async Task<ActionResult> GetSingleton()
    {
        var result = await queryService.Handle(new GetSingletonBillingSettingsQuery());
        if (result == null) return NotFound();
        return Ok(result.ToResource());
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Actualiza configuración", OperationId = "UpdateBillingSettings")]
    [SwaggerResponse(StatusCodes.Status200OK, "Actualizado", typeof(BillingSettingsResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Id mismatch")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No encontrado")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateBillingSettingsResource resource)
    {
        if (id != resource.Id) return BadRequest("Id mismatch");
        try
        {
            var updated = await commandService.Handle(resource.ToCommand());
            if (updated == null) return NotFound();
            return Ok(updated.ToResource());
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtiene por Id (alternativo)", OperationId = "GetBillingSettingsById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Encontrado", typeof(BillingSettingsResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No encontrado")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await queryService.Handle(new GetBillingSettingsByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result.ToResource());
    }
}
