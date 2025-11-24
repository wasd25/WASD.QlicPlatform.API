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


