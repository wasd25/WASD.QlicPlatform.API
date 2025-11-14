namespace WASD.QLicPlatform.API.Subscriptions.Domain.Model.Aggregate;

public class Subscription
{
    public int Id { get; }
    public string Plan { get; }
    public string Price { get; }
    public string Description { get; }

    public Subscription(int id, string plan, string price, string description)
    {
        Id = id;
        Plan = plan;
        Price = price;
        Description = description;
    }
}
