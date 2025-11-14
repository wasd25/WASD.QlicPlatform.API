namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

public record AlertResource(
    long Id,
    string AlertType,
    string Title,
    string Message,
    string Timestamp);