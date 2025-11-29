// Interfaces/REST/Resources/UsageTrendDto.cs
namespace WASD.QLicPlatform.API.Reports.Interfaces.REST.Resources;

public class UsageTrendDto
{
    public DateTime Day { get; set; }  
    public int Liters { get; set; }
}