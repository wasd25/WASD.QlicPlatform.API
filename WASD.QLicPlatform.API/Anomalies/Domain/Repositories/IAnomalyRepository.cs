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
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null);
        Task<IReadOnlyList<Anomaly>> GetByStatusAsync(
            AnomalyStatus status,
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null);
        Task<IReadOnlyList<(DateTime Date, int Count)>> GetTrendAsync(
            DateTime from,
            DateTime to,
            int? profileId = null);
    }
}

