namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class UpdateReportSummaryResource
{
    public string Type { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Period { get; set; } = null!;
}