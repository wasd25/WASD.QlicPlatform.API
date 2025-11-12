// WASD.QLicPlatform.API/Anomalies/Domain/Commands/CreateAnomalyCommand.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Commands
{
    public sealed record CreateAnomalyCommand(
        int ProfileId,
        AnomalyType Type,
        int Severity,
        DateTime DetectedAt,
        string Description,
        string? Metadata);
}