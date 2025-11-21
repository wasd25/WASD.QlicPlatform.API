// WASD.QLicPlatform.API/Anomalies/Domain/Model/Aggregate/Anomaly.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate
{
    public class Anomaly
    {
        public Guid Id { get; private set; }
        public int ProfileId { get; private set; }
        public AnomalyType Type { get; private set; }
        public int Severity { get; private set; }
        public DateTime DetectedAt { get; private set; }
        public string Description { get; private set; }
        public string? Metadata { get; private set; }
        public AnomalyStatus Status { get; private set; }
        public DateTime? ResolvedAt { get; private set; }

        protected Anomaly() { }

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

