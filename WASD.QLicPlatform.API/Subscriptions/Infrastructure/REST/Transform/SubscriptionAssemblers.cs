using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Transform;

public static class SubscriptionAssemblers
{
    public static SubscriptionResource ToResource(this Subscription s) =>
        new(s.Id, s.Plan, s.Price, s.Description);
}