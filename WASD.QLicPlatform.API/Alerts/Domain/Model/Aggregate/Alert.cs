namespace WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;

public partial class Alert
{
    public int Id { get; set; }
    public string AlertType { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public string Timestamp { get; set; }
    
    public Alert(int id, string alertType, string title, string message, string timestamp)
    {
        Id = id;
        AlertType = alertType;
        Title = title;
        Message = message; 
        Timestamp = timestamp;
    }
}