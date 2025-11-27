using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Configuration;

namespace WASD.QLicPlatform.API.Subscriptions.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class SubscriptionsModelBuilderExtensions
{
    public static void ApplySubscriptionsConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SubscriptionConfiguration());
    }
}

