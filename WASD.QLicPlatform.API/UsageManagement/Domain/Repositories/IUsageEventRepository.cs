using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

public interface IUsageEventRepository
{
    Task<IEnumerable<UsageEvent>> GetAllAsync();
    Task<UsageEvent?> GetByIdAsync(Guid id);
    Task AddAsync(UsageEvent usageEvent);
    Task DeleteAsync(Guid id);
}