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
public class PaymentMethodsController(
    IPaymentMethodQueryService paymentMethodQueryService,
    IPaymentMethodCommandService paymentMethodCommandService) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPaymentMethods()
    {
        var getAllPaymentMethodsQuery = new GetAllPaymentMethodsQuery();
        var paymentMethods = await paymentMethodQueryService.Handle(getAllPaymentMethodsQuery);
        var paymentMethodResources = paymentMethods.Select(PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentMethodResources);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentMethodById(int id)
    {
        var getPaymentMethodByIdQuery = new GetPaymentMethodByIdQuery(id);
        var paymentMethod = await paymentMethodQueryService.Handle(getPaymentMethodByIdQuery);
        
        if (paymentMethod == null)
            return NotFound();
        
        var paymentMethodResource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(paymentMethod);
        return Ok(paymentMethodResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodResource resource)
    {
        var createPaymentMethodCommand = CreatePaymentMethodCommandFromResourceAssembler.ToCommandFromResource(resource);
        var paymentMethod = await paymentMethodCommandService.Handle(createPaymentMethodCommand);
        
        if (paymentMethod == null)
            return BadRequest();
        
        var paymentMethodResource = PaymentMethodResourceFromEntityAssembler.ToResourceFromEntity(paymentMethod);
        return CreatedAtAction(nameof(GetPaymentMethodById), new { id = paymentMethod.Id }, paymentMethodResource);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentMethod(int id)
    {
        var deletePaymentMethodCommand = new DeletePaymentMethodCommand(id);
        var result = await paymentMethodCommandService.Handle(deletePaymentMethodCommand);
        
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}

