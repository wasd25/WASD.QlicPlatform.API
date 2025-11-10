using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Transform;

public class UpdateAlertCommandFromResourceAssembler
{
    public static UpdateAlertCommand ToCommandFromResource(UpdateAlertResource resource)
    {
        return new UpdateAlertCommand(
            resource.AlertId,
            resource.AlertType,
            resource.Title,
            resource.Message,
            resource.Timestamp);
    }
}