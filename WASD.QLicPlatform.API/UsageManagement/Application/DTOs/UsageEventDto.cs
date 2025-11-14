namespace WASD.QLicPlatform.API.UsageManagement.Application.DTOs;

public class UsageEventDto
{
    public string Id { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty; // formato HH:mm
    public int Amount { get; set; }
    public string Source { get; set; } = string.Empty;
}