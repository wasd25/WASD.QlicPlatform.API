// WASD.QLicPlatform.API/Anomalies/Domain/Repositories/IAnomalyRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Repositories
{
    public interface IAnomalyRepository
    {
        Task<Anomaly?> GetByIdAsync(Guid id);
        Task AddAsync(Anomaly anomaly);
        Task UpdateAsync(Anomaly anomaly);
        Task DeleteAsync(Guid id);

        Task<IReadOnlyList<Anomaly>> GetAllAsync(
            int? profileId,
            DateTime? from,
            DateTime? to,
            int? page,
            int? pageSize);

        Task<IReadOnlyList<Anomaly>> GetByStatusAsync(
            AnomalyStatus status,
            int? profileId,
            DateTime? from,
            DateTime? to,
            int? page,
            int? pageSize);

        // Devuelve pares fecha-cantidad para trend
        Task<IReadOnlyList<(DateTime Date, int Count)>> GetTrendAsync(
            DateTime from,
            DateTime to,
            int? profileId);
    }
}