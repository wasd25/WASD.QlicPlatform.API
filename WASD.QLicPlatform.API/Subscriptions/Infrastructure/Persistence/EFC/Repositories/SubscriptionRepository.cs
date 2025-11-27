using WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Subscriptions.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) 
    : BaseRepository<Subscription>(context), ISubscriptionRepository
{
}

