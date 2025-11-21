﻿// WASD.QLicPlatform.API/Anomalies/Interfaces/REST/Resources/UpdateAnomalyStatusResource.cs
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Interfaces.REST.Resources
{
    public class UpdateAnomalyStatusResource
    {
        [Required]
        [Range(1, 3, ErrorMessage = "NewStatus debe ser 1 (Unresolved), 2 (Resolved) o 3 (Dismissed)")]
        [DefaultValue(AnomalyStatus.Resolved)]
        public AnomalyStatus NewStatus { get; set; }
        
        public DateTime? ResolvedAt { get; set; }
    }
}