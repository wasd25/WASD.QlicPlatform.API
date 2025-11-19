namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

public record CreateAlertResource(string AlertType, string Title, string Message, string Timestamp);