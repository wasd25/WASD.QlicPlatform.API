using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Transform;

public class AlertResourceFromEntityAssembler
{
    public static AlertResource ToResourceFromEntity(Alert alert)
    {
        return new AlertResource(
            alert.Id, 
            alert.type, 
            alert.Title, 
            alert.Message, 
            alert.Timestamp);
    }
}