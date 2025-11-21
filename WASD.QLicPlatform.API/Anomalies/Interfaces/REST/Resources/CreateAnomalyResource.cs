﻿// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Resources/CreateAnomalyResource.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources
{
    public class CreateAnomalyResource
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ProfileId debe ser mayor a 0")]
        [DefaultValue(1)]
        public int ProfileId { get; set; }
        
        [Required]
        [DefaultValue(AnomalyType.LeakDetected)]
        public AnomalyType Type { get; set; }
        
        [Required]
        [Range(1, 5, ErrorMessage = "Severity debe estar entre 1 y 5")]
        [DefaultValue(3)]
        public int Severity { get; set; }
        
        [Required]
        public DateTime DetectedAt { get; set; }
        
        [Required]
        [StringLength(500, MinimumLength = 1)]
        [DefaultValue("Fuga detectada en sensor principal")]
        public string Description { get; set; } = string.Empty;
        
        [DefaultValue("{\"sensorId\": \"S001\", \"location\": \"Zone A\"}")]
        public string? Metadata { get; set; }
    }
}