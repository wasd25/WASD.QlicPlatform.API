using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Alerts.Domain.Repositories;

public interface IAlertRepository : IBaseRepository<Alert>
{
    Task<IEnumerable<Alert>> findByTitleAsync(string title);
}