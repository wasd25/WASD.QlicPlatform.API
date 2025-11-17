namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

public record UpdateAlertCommand(int AlertId, string Type, string Title, string Message, string Timestamp);