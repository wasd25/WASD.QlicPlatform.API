namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

public record UpdateAlertResource(string AlertType, string Title, string Message, string Timestamp);