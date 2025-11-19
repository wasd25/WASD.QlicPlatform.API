using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class UsageEventsResourceFromEntityAssembler
{
    public static UsageEventsResource ToResourceFromEntity(UsageEvents usageEvents)
    {
        return new UsageEventsResource(
            usageEvents.Id,
            usageEvents.Time,
            usageEvents.Amount,
            usageEvents.Source);
    }
}