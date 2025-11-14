// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Resources/AnomalyResource.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources
{
    public class AnomalyResource
    {
        public Guid Id { get; set; }
        public int ProfileId { get; set; }
        public AnomalyType Type { get; set; }
        public AnomalyStatus Status { get; set; }
        public int Severity { get; set; }
        public DateTime DetectedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string Description { get; set; }
        public string? Metadata { get; set; }
    }
}