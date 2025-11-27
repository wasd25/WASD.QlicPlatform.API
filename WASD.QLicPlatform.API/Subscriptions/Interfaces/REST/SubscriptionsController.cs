using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;
using WASD.QLicPlatform.API.Subscriptions.Domain.Services;
using WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionsController(ISubscriptionQueryService subscriptionQueryService) 
    : ControllerBase
{
    /// <summary>
    /// Get subscription plan by ID
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSubscriptionById(int id)
    {
        var getSubscriptionByIdQuery = new GetSubscriptionByIdQuery(id);
        var subscription = await subscriptionQueryService.Handle(getSubscriptionByIdQuery);
        
        if (subscription == null)
            return NotFound(new { message = $"Subscription with ID {id} not found." });
        
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(subscriptionResource);
    }
}

