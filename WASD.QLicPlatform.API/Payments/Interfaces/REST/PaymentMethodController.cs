using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/paymentMethods")]
[SwaggerTag("Payment Methods operations")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("PaymentMethods")]
public class PaymentMethodsController(IPaymentMethodCommandService commandService, IPaymentMethodQueryService queryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Crea un método de pago", OperationId = "CreatePaymentMethod")]
    [SwaggerResponse(StatusCodes.Status201Created, "Creado", typeof(PaymentMethodResource))]
    public async Task<ActionResult> Create([FromBody] CreatePaymentMethodResource resource)
    {
        var created = await commandService.Handle(resource.ToCommand());
        return CreatedAtAction(nameof(GetById), new { id = created!.Id }, created.ToResource());
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtiene un método de pago por Id", OperationId = "GetPaymentMethodById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Encontrado", typeof(PaymentMethodResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No encontrado")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var result = await queryService.Handle(new GetPaymentMethodByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result.ToResource());
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Lista métodos de pago", OperationId = "GetAllPaymentMethods")]
    [SwaggerResponse(StatusCodes.Status200OK, "Listado", typeof(IEnumerable<PaymentMethodResource>))]
    public async Task<ActionResult> GetAll()
    {
        var list = await queryService.Handle(new GetAllPaymentMethodsQuery());
        return Ok(list.Select(x => x.ToResource()));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Actualiza un método de pago", OperationId = "UpdatePaymentMethod")]
    [SwaggerResponse(StatusCodes.Status200OK, "Actualizado", typeof(PaymentMethodResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Id mismatch")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdatePaymentMethodResource resource)
    {
        if (id != resource.Id) return BadRequest("Id mismatch");
        var updated = await commandService.Handle(resource.ToCommand());
        return Ok(updated!.ToResource());
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Elimina un método de pago", OperationId = "DeletePaymentMethod")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Eliminado")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await commandService.Handle(new Domain.Model.Commands.DeletePaymentMethodCommand(id));
        return NoContent();
    }
}
