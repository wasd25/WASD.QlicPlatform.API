using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Payment operations")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Payments")]
public class PaymentsController(IPaymentCommandService paymentCommandService, IPaymentQueryService paymentQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new Payment", Description = "Creates a new Payment", OperationId = "CreatePayment")]
    [SwaggerResponse(StatusCodes.Status201Created, "The Payment Was Created", typeof(PaymentResource))]
    public async Task<ActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var cmd = resource.ToCommand();
        var result = await paymentCommandService.Handle(cmd);
        if (result == null) return BadRequest();
        return CreatedAtAction(nameof(GetPaymentById), new { id = result.Id }, result.ToResource());
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Gets a Payment by Id", Description = "Gets a Payment by Id", OperationId = "GetPaymentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Payment Was Found", typeof(PaymentResource))]
    public async Task<ActionResult> GetPaymentById([FromRoute] GetPaymentByIdQuery query)
    {
        var result = await paymentQueryService.Handle(query);
        if (result == null) return NotFound();
        return Ok(result.ToResource());
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Gets all Payments", Description = "Gets all Payments", OperationId = "GetAllPayments")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Payments Were Found", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await paymentQueryService.Handle(new GetAllPaymentsQuery());
        return Ok(payments.Select(p => p.ToResource()).ToList());
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Updates a Payment", Description = "Updates a Payment", OperationId = "UpdatePayment")]
    [SwaggerResponse(StatusCodes.Status200OK, "The Payment Was Updated", typeof(PaymentResource))]
    public async Task<ActionResult> UpdatePayment([FromRoute] int id, [FromBody] UpdatePaymentResource resource)
    {
        if (id != resource.Id) return BadRequest("Id mismatch");
        var cmd = resource.ToCommand();
        var result = await paymentCommandService.Handle(cmd);
        if (result == null) return NotFound("The Payment Was Not Found");
        return Ok(result.ToResource());
    }
    
}
