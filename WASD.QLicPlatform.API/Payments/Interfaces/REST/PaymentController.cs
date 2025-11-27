using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentsController(
    IPaymentQueryService paymentQueryService,
    IPaymentCommandService paymentCommandService) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var getAllPaymentsQuery = new GetAllPaymentsQuery();
        var payments = await paymentQueryService.Handle(getAllPaymentsQuery);
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(id);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        
        if (payment == null)
            return NotFound();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        
        if (payment == null)
            return BadRequest();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, paymentResource);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentResource resource)
    {
        var updatePaymentCommand = UpdatePaymentCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var payment = await paymentCommandService.Handle(updatePaymentCommand);
        
        if (payment == null)
            return NotFound();
        
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var deletePaymentCommand = new DeletePaymentCommand(id);
        var result = await paymentCommandService.Handle(deletePaymentCommand);
        
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}