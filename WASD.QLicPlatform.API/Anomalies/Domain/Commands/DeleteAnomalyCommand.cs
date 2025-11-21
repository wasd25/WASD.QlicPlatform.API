// WASD.QLicPlatform.API/Anomalies/Domain/Commands/DeleteAnomalyCommand.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Commands
{
    public record DeleteAnomalyCommand(Guid AnomalyId);
}

