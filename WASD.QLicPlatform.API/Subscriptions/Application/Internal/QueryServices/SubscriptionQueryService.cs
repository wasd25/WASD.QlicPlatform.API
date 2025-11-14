using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Queries;
using WASD.QLicPlatform.API.Subscriptions.Domain.Repositories;
using WASD.QLicPlatform.API.Subscriptions.Domain.Services;

namespace WASD.QLicPlatform.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository repository) : ISubscriptionQueryService
{
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionsQuery query) =>
        await repository.ListAsync();

    public async Task<Subscription?> Handle(GetSubscriptionByIdQuery query) =>
        await repository.FindByIdAsync(query.Id);
}