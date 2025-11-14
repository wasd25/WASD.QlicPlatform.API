// WASD.QLicPlatform.API/Anomalies/Domain/Commands/DeleteAnomalyCommand.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Commands
{
    public sealed record DeleteAnomalyCommand(Guid AnomalyId);
}