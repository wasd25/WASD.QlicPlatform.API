// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAnomaliesByStatusQuery.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public sealed record GetAnomaliesByStatusQuery(
        AnomalyStatus Status,
        int? ProfileId,
        int? Page,
        int? PageSize,
        DateTime? From,
        DateTime? To);
}