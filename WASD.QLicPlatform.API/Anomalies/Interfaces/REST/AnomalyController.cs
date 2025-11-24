﻿// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/AnomalyController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Services;
using WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnomalyController : ControllerBase
    {
        private readonly IAnomalyCommandService _commandService;
        private readonly IAnomalyQueryService _queryService;

        public AnomalyController(IAnomalyCommandService commandService, IAnomalyQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnomalyResource resource)
        {
            try
            {
                var command = CreateAnomalyCommandFromResourceAssembler.ToCommand(resource);
                var anomaly = await _commandService.HandleAsync(command);
                var anomalyResource = AnomalyResourceFromEntityAssembler.ToResource(anomaly);
                return CreatedAtAction(nameof(GetById), new { id = anomaly.Id }, anomalyResource);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var anomaly = await _queryService.HandleAsync(id);
            if (anomaly == null) return NotFound();
            return Ok(AnomalyResourceFromEntityAssembler.ToResource(anomaly));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? profileId, [FromQuery] DateTime? from, [FromQuery] DateTime? to, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var anomalies = await _queryService.HandleAsync(profileId, from, to, page, pageSize);
            return Ok(anomalies.Select(AnomalyResourceFromEntityAssembler.ToResource));
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateAnomalyStatusResource resource)
        {
            try
            {
                var command = UpdateAnomalyStatusCommandFromResourceAssembler.ToCommand(id, resource);
                var anomaly = await _commandService.HandleAsync(command);
                if (anomaly == null) return NotFound(new { message = "Anomaly not found" });
                return Ok(AnomalyResourceFromEntityAssembler.ToResource(anomaly));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _commandService.HandleAsync(new Domain.Commands.DeleteAnomalyCommand(id));
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("trend")]
        public async Task<IActionResult> GetTrend([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int? profileId)
        {
            var trend = await _queryService.HandleTrendAsync(from, to, profileId);
            return Ok(trend.Select(t => new { Date = t.Date, Count = t.Count }));
        }
    }
}
