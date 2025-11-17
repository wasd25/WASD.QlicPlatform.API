using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;

public partial class Alert
{
    public int Id { get; }
    public string Type { get; private set; }
    public string Title { get; private set; }
    public string Message { get; private set; }
    public string Timestamp { get; private set; }
    
    public Alert(int id, string type, string title, string message, string timestamp)
    {
        Id = id;
        Type = type;
        Title = title;
        Message = message; 
        Timestamp = timestamp;
    }

    public Alert(CreateAlertCommand createAlertCommand)
    {
        this.Type = createAlertCommand.type;
        this.Title = createAlertCommand.Title;
        this.Message = createAlertCommand.Message;
        this.Timestamp = createAlertCommand.Timestamp;
    }

    public Alert(UpdateAlertCommand updateAlertCommand)
    {
        this.Type = updateAlertCommand.type;
        this.Title = updateAlertCommand.Title;
        this.Message = updateAlertCommand.Message;
        this.Timestamp = updateAlertCommand.Timestamp;
    }
}