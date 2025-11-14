using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Subscriptions.Domain.Repositories;

namespace WASD.QLicPlatform.API.Subscriptions.Infrastructure.Persistence;

public class InMemorySubscriptionRepository : ISubscriptionRepository
{
    private static readonly List<Subscription> Data =
    [
        new(1, "Basic Plan", "$19/month", "Access to standard features with limited support."),
        new(2, "Pro Plan", "$49/month", "Includes premium tools and priority support."),
        new(3, "Enterprise Plan", "Custom", "Full access and dedicated account management.")
    ];

    public Task<IEnumerable<Subscription>> ListAsync() => Task.FromResult(Data.AsEnumerable());
    public Task<Subscription?> FindByIdAsync(int id) =>
        Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
}