namespace WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

public record CreateUsageEventCommand(string Time, int Amount, string Source);