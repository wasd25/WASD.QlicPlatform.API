using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Transform;

public static class ReportResourceAssembler
{
    public static ReportResource ToResource(Report report)
    {
        return new ReportResource
        {
            Id = report.Id,
            Title = report.Title,
            Description = report.Description,
            CreatedAt = report.CreatedAt,
            UpdatedAt = report.UpdatedAt
        };
    }
}