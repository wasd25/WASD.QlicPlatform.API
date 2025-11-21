using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class CreateUsageEventsCommandFromResourceAssembler
{
    public static CreateUsageEventCommand ToCommandFromResource(
        CreateUsageEventsResource resource)
    {
        return new CreateUsageEventCommand(
            resource.Time,
            resource.Amount,
            resource.Source);
    }
}