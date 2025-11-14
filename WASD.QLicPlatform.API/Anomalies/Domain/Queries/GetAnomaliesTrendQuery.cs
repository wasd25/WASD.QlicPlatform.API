// WASD.QLicPlatform.API/Anomalies/Domain/Queries/GetAnomaliesTrendQuery.cs
using System;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Queries
{
    // Agregación por día para la gráfica de tendencias
    public sealed record GetAnomaliesTrendQuery(
        DateTime From,
        DateTime To,
        int? ProfileId);
}