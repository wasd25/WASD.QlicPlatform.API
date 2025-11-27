using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;
using WASD.QLicPlatform.API.Subscriptions.Domain.Repositories;
using WASD.QLicPlatform.API.Subscriptions.Domain.Services;

namespace WASD.QLicPlatform.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository subscriptionRepository) 
    : ISubscriptionQueryService
{
    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query)
    {
        return await subscriptionRepository.FindByIdAsync(query.Id);
    }
}

