using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Alerts.Interfaces.REST.Transform;

public class DeleteAlertCommandFromResourceAssembler
{
    public static DeleteAlertCommand ToCommandFromResource(
        DeleteAlertResource resource)
    {
        return new DeleteAlertCommand(resource.AlertId);
    }
}