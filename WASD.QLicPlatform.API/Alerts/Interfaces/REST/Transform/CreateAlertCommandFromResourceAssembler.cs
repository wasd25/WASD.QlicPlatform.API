using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Transform;

public class CreateAlertCommandFromResourceAssembler
{
    public static CreateAlertCommand ToCommandFromResource(
        CreateAlertResource resource)
    {
        return new CreateAlertCommand(
            resource.AlertType,
            resource.Title,
            resource.Message,
            resource.Timestamp);
    }
}