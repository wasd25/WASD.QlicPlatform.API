// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAllAnomaliesQuery.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public sealed record GetAllAnomaliesQuery(
        int? ProfileId,
        int? Page,
        int? PageSize,
        DateTime? From,
        DateTime? To);
}