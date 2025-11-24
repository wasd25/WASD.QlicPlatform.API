// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAllAnomaliesQuery.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public record GetAllAnomaliesQuery(
        int? ProfileId = null,
        DateTime? From = null,
        DateTime? To = null,
        int? Page = null,
        int? PageSize = null);
}

