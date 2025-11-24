using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;

public interface IUsageEventsRepository : IBaseRepository<UsageEvents>
{
    Task<IEnumerable<UsageEvents>> findBySourceAsync(string source);
}