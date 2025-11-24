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
        public int Severity { get; set; }
        public DateTime DetectedAt { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Metadata { get; set; }
        public AnomalyStatus Status { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}

