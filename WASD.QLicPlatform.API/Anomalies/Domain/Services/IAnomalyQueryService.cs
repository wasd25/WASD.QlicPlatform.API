// WASD.QLicPlatform.API/Anomalies/Domain/Services/IAnomalyQueryService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Services
{
    public interface IAnomalyQueryService
    {
        Task<Anomaly?> HandleAsync(Guid anomalyId);
        Task<IReadOnlyList<Anomaly>> HandleAsync(int? profileId, DateTime? from, DateTime? to, int? page, int? pageSize);
        Task<IReadOnlyList<Anomaly>> HandleByStatusAsync(Shared.Domain.Enums.AnomalyStatus status, int? profileId, DateTime? from, DateTime? to, int? page, int? pageSize);
        Task<IReadOnlyList<(DateTime Date, int Count)>> HandleTrendAsync(DateTime from, DateTime to, int? profileId);
    }
}