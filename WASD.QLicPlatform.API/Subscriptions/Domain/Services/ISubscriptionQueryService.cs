using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query);
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
}
