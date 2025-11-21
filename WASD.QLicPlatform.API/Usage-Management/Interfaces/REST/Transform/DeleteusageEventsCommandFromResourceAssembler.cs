using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class DeleteusageEventsCommandFromResourceAssembler
{
    public static DeleteUsageEventCommand ToCommandFromResource(
        DeleteUsageEventsResource resource)
    {
        return new DeleteUsageEventCommand(resource.UsageEventId);
    }
}