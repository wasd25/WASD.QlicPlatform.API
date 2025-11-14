// WASD.QLicPlatform.API/Anomalies/Application/Internal/CommandServices/AnomalyCommandService.cs
using System;
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Commands;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Anomalies.Domain.Repositories;
using WASD.QLicPlatform.API.Anomalies.Domain.Services;

namespace WASD.QLicPlatform.API.Anomalies.Application.Internal.CommandServices
{
    public sealed class AnomalyCommandService : IAnomalyCommandService
    {
        private readonly IAnomalyRepository _repository;

        public AnomalyCommandService(IAnomalyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anomaly> HandleAsync(CreateAnomalyCommand command)
        {
            var anomaly = new Anomaly(
                Guid.NewGuid(),
                command.ProfileId,
                command.Type,
                command.Severity,
                command.DetectedAt,
                command.Description,
                command.Metadata);

            await _repository.AddAsync(anomaly);
            return anomaly;
        }

        public async Task<Anomaly?> HandleAsync(UpdateAnomalyStatusCommand command)
        {
            var anomaly = await _repository.GetByIdAsync(command.AnomalyId);
            if (anomaly is null) return null;

            switch (command.NewStatus)
            {
                case Shared.Domain.Enums.AnomalyStatus.Resolved:
                    anomaly.Resolve(command.ResolvedAt ?? DateTime.UtcNow);
                    break;
                case Shared.Domain.Enums.AnomalyStatus.Dismissed:
                    anomaly.Dismiss();
                    break;
                default:
                    throw new InvalidOperationException("Unsupported status update.");
            }

            await _repository.UpdateAsync(anomaly);
            return anomaly;
        }

        public async Task<bool> HandleAsync(DeleteAnomalyCommand command)
        {
            var anomaly = await _repository.GetByIdAsync(command.AnomalyId);
            if (anomaly is null) return false;

            await _repository.DeleteAsync(command.AnomalyId);
            return true;
        }
    }
}
