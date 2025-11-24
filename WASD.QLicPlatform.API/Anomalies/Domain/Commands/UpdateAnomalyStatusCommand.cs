// WASD.QLicPlatform.API/Anomalies/Domain/Commands/UpdateAnomalyStatusCommand.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Commands
{
    public record UpdateAnomalyStatusCommand(
        Guid AnomalyId,
        AnomalyStatus NewStatus,
        DateTime? ResolvedAt = null);
}

