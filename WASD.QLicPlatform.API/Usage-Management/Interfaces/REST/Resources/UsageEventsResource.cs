namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

public record UsageEventsResource(
    long Id,
    string Time,
    int Amount,
    string Source);