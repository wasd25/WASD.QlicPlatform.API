using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(
            entity.Id,
            entity.Plan,
            entity.Price,
            entity.Description
        );
    }
}

