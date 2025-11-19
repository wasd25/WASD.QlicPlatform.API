using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Transform;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST;

[ApiController]
[Route("api/v1/reportSummaries")]
public class ReportSummariesController : ControllerBase
{
    private readonly AppDbContext _db;

    public ReportSummariesController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var summaries = await _db.ReportSummaries
            .Include(x => x.UsageTrends)
            .Include(x => x.CostBreakdown)
            .Include(x => x.EfficiencyMetrics)
            .ToListAsync();

        var resources = ReportSummaryResourceAssembler.ToResourceList(summaries);
        return Ok(resources);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var summary = await _db.ReportSummaries
            .Include(x => x.UsageTrends)
            .Include(x => x.CostBreakdown)
            .Include(x => x.EfficiencyMetrics)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (summary is null) return NotFound();

        var resource = ReportSummaryResourceAssembler.ToResource(summary);
        return Ok(resource);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReportSummaryResource resource)
    {
        var summary = new ReportSummary
        {
            Type = resource.Type,
            Location = resource.Location,
            Period = resource.Period,
            Resource = resource.Resource,

            EfficiencyMetrics = resource.EfficiencyMetrics is not null
                ? new EfficiencyMetrics
                {
                    Score = resource.EfficiencyMetrics.Score,
                    WaterSaved = resource.EfficiencyMetrics.WaterSaved,
                    CostSaved = resource.EfficiencyMetrics.CostSaved
                }
                : null,

            UsageTrends = resource.UsageTrends?.Select(x => new UsageTrend
            {
                Day = x.Day,
                Liters = x.Liters
            }).ToList(),

            CostBreakdown = resource.CostBreakdown?.Select(x => new CostBreakdown
            {
                Category = x.Category,
                Cost = x.Cost
            }).ToList()
        };

        _db.ReportSummaries.Add(summary);
        await _db.SaveChangesAsync();

        var createdResource = ReportSummaryResourceAssembler.ToResource(summary);
        return CreatedAtAction(nameof(GetById), new { id = summary.Id }, createdResource);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateReportSummaryResource resource)
    {
        var summary = await _db.ReportSummaries.FindAsync(id);
        if (summary is null) return NotFound();

        summary.Type = resource.Type;
        summary.Location = resource.Location;
        summary.Period = resource.Period;

        _db.ReportSummaries.Update(summary);
        await _db.SaveChangesAsync();

        var updatedResource = ReportSummaryResourceAssembler.ToResource(summary);
        return Ok(updatedResource);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var summary = await _db.ReportSummaries.FindAsync(id);
        if (summary is null) return NotFound();

        _db.ReportSummaries.Remove(summary);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
