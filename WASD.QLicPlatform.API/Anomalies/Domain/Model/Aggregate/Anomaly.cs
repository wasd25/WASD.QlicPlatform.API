// WASD.QLicPlatform.API/Anomalies/Domain/Model/Aggregate/Anomaly.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate
{
    public sealed class Anomaly
    {
        public Guid Id { get; private set; }
        public int ProfileId { get; private set; }
        public AnomalyType Type { get; private set; }
        public AnomalyStatus Status { get; private set; }
        public int Severity { get; private set; } // 1..3 o 1..5 según tu UI
        public DateTime DetectedAt { get; private set; }
        public DateTime? ResolvedAt { get; private set; }
        public string Description { get; private set; }
        public string? Metadata { get; private set; } // JSON opcional (sensorId, location, etc.)

        private Anomaly() { } // Para EF

        public Anomaly(
            Guid id,
            int profileId,
            AnomalyType type,
            int severity,
            DateTime detectedAt,
            string description,
            string? metadata = null)
        {
            if (severity < 1) throw new ArgumentOutOfRangeException(nameof(severity), "Severity must be >= 1.");
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            ProfileId = profileId;
            Type = type;
            Severity = severity;
            DetectedAt = detectedAt;
            Description = description;
            Metadata = metadata;
            Status = AnomalyStatus.Unresolved;
        }

        public void Resolve(DateTime resolvedAt)
        {
            if (Status == AnomalyStatus.Resolved) return;
            Status = AnomalyStatus.Resolved;
            ResolvedAt = resolvedAt;
        }

        public void Dismiss()
        {
            if (Status == AnomalyStatus.Resolved) throw new InvalidOperationException("Cannot dismiss a resolved anomaly.");
            Status = AnomalyStatus.Dismissed;
            ResolvedAt = null;
        }

        public void UpdateSeverity(int severity)
        {
            if (severity < 1) throw new ArgumentOutOfRangeException(nameof(severity), "Severity must be >= 1.");
            Severity = severity;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateMetadata(string? metadata)
        {
            Metadata = metadata;
        }
    }
}
