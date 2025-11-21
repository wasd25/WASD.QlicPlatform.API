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

        public async Task<Anomaly?> HandleAsync(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IReadOnlyList<Anomaly>> HandleAsync(
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null) =>
            await _repository.GetAllAsync(profileId, from, to, page, pageSize);

        public async Task<IReadOnlyList<Anomaly>> HandleByStatusAsync(
            AnomalyStatus status,
            int? profileId = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            int? pageSize = null) =>
            await _repository.GetByStatusAsync(status, profileId, from, to, page, pageSize);

        public async Task<IReadOnlyList<(DateTime Date, int Count)>> HandleTrendAsync(
            DateTime from,
            DateTime to,
            int? profileId = null) =>
            await _repository.GetTrendAsync(from, to, profileId);
    }
}

