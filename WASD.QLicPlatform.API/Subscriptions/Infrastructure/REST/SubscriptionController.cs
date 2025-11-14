using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;
using WASD.QLicPlatform.API.Subscriptions.Domain.Services;
using WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Transform;
using WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/subscriptions")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Subscription catalog (read-only)")]
[Tags("Subscriptions")]
public class SubscriptionsController(ISubscriptionQueryService queryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Lista todas las suscripciones", OperationId = "GetAllSubscriptions")]
    [SwaggerResponse(StatusCodes.Status200OK, "Listado", typeof(IEnumerable<SubscriptionResource>))]
    public async Task<ActionResult> GetAll()
    {
        var list = await queryService.Handle(new GetAllSubscriptionsQuery());
        return Ok(list.Select(x => x.ToResource()));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtiene una suscripción por Id", OperationId = "GetSubscriptionById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Encontrada", typeof(SubscriptionResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No encontrada")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await queryService.Handle(new GetSubscriptionByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result.ToResource());
    }
}