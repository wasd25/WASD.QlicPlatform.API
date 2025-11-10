namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

public record UpdateAlertResource(int AlertId, string AlertType, string Title, string Message, string Timestamp);