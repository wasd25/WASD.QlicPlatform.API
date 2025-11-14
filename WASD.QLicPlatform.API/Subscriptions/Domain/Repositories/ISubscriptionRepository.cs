using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> ListAsync();
    Task<Subscription?> FindByIdAsync(int id);
}