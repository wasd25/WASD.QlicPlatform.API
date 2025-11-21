using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class UpdateUsageEventsCommandFromAssembler
{
    public static UpdateUsageEventCommand ToCommandFromResource(int id, UpdateUsageEventsResource resource)
    {
        return new UpdateUsageEventCommand(
            id,
            resource.Time,
            resource.Amount,
            resource.Source);
    }
}