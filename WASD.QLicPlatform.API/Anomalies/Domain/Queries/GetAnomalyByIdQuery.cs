// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAnomalyByIdQuery.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public sealed record GetAnomalyByIdQuery(Guid AnomalyId);
}