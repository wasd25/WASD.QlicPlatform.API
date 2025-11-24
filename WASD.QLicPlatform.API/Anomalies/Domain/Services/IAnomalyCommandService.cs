// WASD.QLicPlatform.API/Anomalies/Domain/Services/IAnomalyCommandService.cs
using System.Threading.Tasks;
using WASD.QLicPlatform.API.Anomalies.Domain.Commands;
using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Anomalies.Domain.Services
{
    public interface IAnomalyCommandService
    {
        Task<Anomaly> HandleAsync(CreateAnomalyCommand command);
        Task<Anomaly?> HandleAsync(UpdateAnomalyStatusCommand command);
        Task<bool> HandleAsync(DeleteAnomalyCommand command);
    }
}

