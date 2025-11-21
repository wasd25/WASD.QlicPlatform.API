// WASD.QLicPlatform.API/Anomalies/Domain/Services/IAnomalyQueryService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Services
{
    public interface IAnomalyQueryService
    {
        Task<Anomaly?> HandleAsync(Guid id);
        Task<IReadOnlyList<Anomaly>> HandleAsync(
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null);
        Task<IReadOnlyList<Anomaly>> HandleByStatusAsync(
            AnomalyStatus status,
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null);
        Task<IReadOnlyList<(DateTime Date, int Count)>> HandleTrendAsync(
            DateTime from,
            DateTime to,
            int? profileId = null);
    }
}

        public Anomaly(
            Guid id,
            int profileId,
            AnomalyType type,
            int severity,
            DateTime detectedAt,
            string description,
            string? metadata)
        {
            if (profileId <= 0)
                throw new ArgumentOutOfRangeException(nameof(profileId), "ProfileId must be greater than 0");
            if (severity < 1 || severity > 5)
                throw new ArgumentOutOfRangeException(nameof(severity), "Severity must be between 1 and 5");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));

            Id = id;
            ProfileId = profileId;
            Type = type;
            Severity = severity;
            DetectedAt = detectedAt;
            Description = description;
            Metadata = metadata;
            Status = AnomalyStatus.Unresolved;
            ResolvedAt = null;
        }

        public void Resolve(DateTime resolvedAt)
        {
            Status = AnomalyStatus.Resolved;
            ResolvedAt = resolvedAt;
        }

        public void Dismiss()
        {
            Status = AnomalyStatus.Dismissed;
            ResolvedAt = DateTime.UtcNow;
        }
    }
}

