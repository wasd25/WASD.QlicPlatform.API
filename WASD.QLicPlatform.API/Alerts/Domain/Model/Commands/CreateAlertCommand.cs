namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

public record CreateAlertCommand(string AlertType, string Title, string Message, string Timestamp);