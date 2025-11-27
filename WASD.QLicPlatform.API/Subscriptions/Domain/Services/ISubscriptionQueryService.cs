using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<Subscription?> Handle(GetSubscriptionByIdQuery query);
}

