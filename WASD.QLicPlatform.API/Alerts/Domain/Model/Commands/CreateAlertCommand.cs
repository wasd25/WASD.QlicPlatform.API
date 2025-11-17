namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

public record CreateAlertCommand(string type, string Title, string Message, string Timestamp);