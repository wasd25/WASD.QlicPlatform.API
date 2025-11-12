// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Transform/UpdateAnomalyStatusCommandFromResourceAssembler.cs
using System;
using WASD.QLicPlatform.API.Anomalies.Domain.Commands;
using WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Transform
{
    public static class UpdateAnomalyStatusCommandFromResourceAssembler
    {
        public static UpdateAnomalyStatusCommand ToCommand(Guid anomalyId, UpdateAnomalyStatusResource resource)
        {
            return new UpdateAnomalyStatusCommand(
                anomalyId,
                resource.NewStatus,
                resource.ResolvedAt
            );
        }
    }
}