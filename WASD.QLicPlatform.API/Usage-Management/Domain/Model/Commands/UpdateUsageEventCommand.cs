namespace WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

public record UpdateUsageEventCommand(int UsageEventId, string Time, int Amount, string Source);