// Interfaces/REST/Resources/CostBreakdownDto.cs
namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class CostBreakdownDto
{
    public string Category { get; set; } = default!;
    public decimal Cost { get; set; }  // <-- decimal
}