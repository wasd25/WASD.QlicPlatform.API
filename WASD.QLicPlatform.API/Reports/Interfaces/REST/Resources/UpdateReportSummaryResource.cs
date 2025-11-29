// Interfaces/REST/Resources/UpdateReportSummaryResource.cs
using System.ComponentModel.DataAnnotations;

namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class UpdateReportSummaryResource
{
    [Required] public string Type { get; set; } = default!;
    [Required] public string Location { get; set; } = default!;
    [Required] public string Period { get; set; } = default!;
    [Required] public string Resource { get; set; } = default!;
}