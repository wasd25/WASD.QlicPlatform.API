// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAnomaliesTrendQuery.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    public record GetAnomaliesTrendQuery(
        DateTime From,
        DateTime To,
        int? ProfileId = null);
}

