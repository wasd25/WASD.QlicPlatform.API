using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;

public partial class Alerts
{
    public int Id { get; set; }
    public string AlertType { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public string Timestamp { get; set; }
    
    public Alerts(int id, string alertType, string title, string message, string timestamp)
    {
        Id = id;
        AlertType = alertType;
        Title = title;
        Message = message; 
        Timestamp = timestamp;
    }

    public Alerts(CreateAlertsCommand createAlertCommand)
    {
        this.AlertType = createAlertCommand.AlertType;
        this.Title = createAlertCommand.Title;
        this.Message = createAlertCommand.Message;
        this.Timestamp = createAlertCommand.Timestamp;
    }

    public Alerts(UpdateAlertCommand updateAlertCommand)
    {
        this.AlertType = updateAlertCommand.AlertType;
        this.Title = updateAlertCommand.Title;
        this.Message = updateAlertCommand.Message;
        this.Timestamp = updateAlertCommand.Timestamp;
    }
}