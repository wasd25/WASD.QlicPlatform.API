namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

public record CreateAlertsCommand(string AlertType, string Title, string Message, string Timestamp);