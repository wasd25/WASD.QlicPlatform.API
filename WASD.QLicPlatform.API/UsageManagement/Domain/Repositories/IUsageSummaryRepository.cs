using WASD.QLicPlatform.API.UsageManagement.Domain.Models;

namespace WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

public interface IUsageSummaryRepository
{
    Task<UsageSummary?> GetAsync();
    Task AddAsync(UsageSummary summary);
    Task UpdateAsync(UsageSummary summary);
    Task DeleteAsync(Guid id);
}