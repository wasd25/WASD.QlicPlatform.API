// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Transform/CreateAnomalyCommandFromResourceAssembler.cs
using WASD.QLicPlatform.API.Anomalies.Domain.Commands;
using WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Transform
{
    public static class CreateAnomalyCommandFromResourceAssembler
    {
        public static CreateAnomalyCommand ToCommand(CreateAnomalyResource resource)
        {
            return new CreateAnomalyCommand(
                resource.ProfileId,
                resource.Type,
                resource.Severity,
                resource.DetectedAt,
                resource.Description,
                resource.Metadata
            );
        }
    }
}