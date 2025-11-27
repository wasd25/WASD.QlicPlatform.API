namespace WASD.QLicPlatform.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    int Id,
    string Plan,
    string Price,
    string Description
);

