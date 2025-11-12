// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Resources/CreateAnomalyResource.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources
{
    public class CreateAnomalyResource
    {
        public int ProfileId { get; set; }
        public AnomalyType Type { get; set; }
        public int Severity { get; set; }
        public DateTime DetectedAt { get; set; }
        public string Description { get; set; }
        public string? Metadata { get; set; }
    }
}