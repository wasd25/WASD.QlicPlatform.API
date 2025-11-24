// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAnomaliesByStatusQuery.cs
using System;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public record GetAnomaliesByStatusQuery(
        AnomalyStatus Status,
        int? ProfileId = null,
        DateTime? From = null,
        DateTime? To = null,
        int? Page = null,
        int? PageSize = null);
}

