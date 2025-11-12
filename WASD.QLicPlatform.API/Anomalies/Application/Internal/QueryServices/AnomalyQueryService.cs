// WASD.QLicPlatform.API/Anomalies/Application/Internal/QueryServices/AnomalyQueryService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Anomalies.Domain.Repositories;
using WASD.QLicPlatform.API.Anomalies.Domain.Services;
using WASD.QLicPlatform.API.Shared.Domain.Enums;

namespace WASD.QLicPlatform.API.Anomalies.Application.Internal.QueryServices
{
    public sealed class AnomalyQueryService : IAnomalyQueryService
    {
        private readonly IAnomalyRepository _repository;

        public AnomalyQueryService(IAnomalyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anomaly?> HandleAsync(Guid anomalyId)
        {
            return await _repository.GetByIdAsync(anomalyId);
        }

        public async Task<IReadOnlyList<Anomaly>> HandleAsync(
            int? profileId,
            DateTime? from,
            DateTime? to,
            int? page,
            int? pageSize)
        {
            return await _repository.GetAllAsync(profileId, from, to, page, pageSize);
        }

        public async Task<IReadOnlyList<Anomaly>> HandleByStatusAsync(
            AnomalyStatus status,
            int? profileId,
            DateTime? from,
            DateTime? to,
            int? page,
            int? pageSize)
        {
            return await _repository.GetByStatusAsync(status, profileId, from, to, page, pageSize);
        }

        public async Task<IReadOnlyList<(DateTime Date, int Count)>> HandleTrendAsync(
            DateTime from,
            DateTime to,
            int? profileId)
        {
            return await _repository.GetTrendAsync(from, to, profileId);
        }
    }
}