using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

public partial class UsageEvents
{
    public int Id { get; set; }
    public string Time { get; private set; }
    public int Amount { get; private set; }
    public string Source { get; private set; }

    public UsageEvents(int id, string time, int amount, string source)
    {
        Id = id;
        Time = time;
        Amount = amount;
        Source = source;
    }

    public UsageEvents(CreateUsageEventCommand createUsageEventCommand)
    {
        this.Time = createUsageEventCommand.Time;
        this.Amount = createUsageEventCommand.Amount;
        this.Source = createUsageEventCommand.Source;
    }

    public UsageEvents(UpdateUsageEventCommand updateUsageEventCommand)
    {
        this.Time = updateUsageEventCommand.Time;
        this.Amount = updateUsageEventCommand.Amount;
        this.Source = updateUsageEventCommand.Source;
    }

    public void Update(string time, int amount, string source)
    {
        Time = time;
        Amount = amount;
        Source = source;
    }
}