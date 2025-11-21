
namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Transform
{
    public static class AnomalyResourceFromEntityAssembler
    {
        public static AnomalyResource ToResource(Anomaly entity)
        {
            return new AnomalyResource
            {
                Id = entity.Id,
                ProfileId = entity.ProfileId,
                Type = entity.Type,
                Severity = entity.Severity,
                DetectedAt = entity.DetectedAt,
                Description = entity.Description,
                Metadata = entity.Metadata,
                Status = entity.Status,
                ResolvedAt = entity.ResolvedAt
            };
        }
    }
}
// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Transform/AnomalyResourceFromEntityAssembler.cs
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources;

