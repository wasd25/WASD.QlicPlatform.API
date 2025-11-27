using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Services;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BillingSettingsController(
    IBillingSettingQueryService billingSettingQueryService,
    IBillingSettingCommandService billingSettingCommandService) 
    : ControllerBase
{
    /// <summary>
    /// Get the billing settings (only one record exists)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetBillingSettings()
    {
        var getBillingSettingQuery = new GetBillingSettingQuery();
        var billingSetting = await billingSettingQueryService.Handle(getBillingSettingQuery);
        
        if (billingSetting == null)
            return NotFound(new { message = "Billing settings not found. Please create one first." });
        
        var billingSettingResource = BillingSettingResourceFromEntityAssembler.ToResourceFromEntity(billingSetting);
        return Ok(billingSettingResource);
    }

    /// <summary>
    /// Update billing settings
    /// </summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateBillingSettings(int id, [FromBody] UpdateBillingSettingResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var updateBillingSettingCommand = UpdateBillingSettingCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var billingSetting = await billingSettingCommandService.Handle(updateBillingSettingCommand);
        
        if (billingSetting == null)
            return NotFound(new { message = "Billing settings not found." });
        
        var billingSettingResource = BillingSettingResourceFromEntityAssembler.ToResourceFromEntity(billingSetting);
        return Ok(billingSettingResource);
    }
}

