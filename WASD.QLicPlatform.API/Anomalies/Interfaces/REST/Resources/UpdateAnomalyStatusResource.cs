// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Resources/UpdateAnomalyStatusResource.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources
{
    public class UpdateAnomalyStatusResource
    {
        public AnomalyStatus NewStatus { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}