using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

namespace WASD.QLicPlatform.API.UsageManagement.Application.Internal.CommandServices;

public class UsageSummaryCommandService
{
    private readonly IUsageSummaryRepository _repository;

    public UsageSummaryCommandService(IUsageSummaryRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsageSummary> CreateAsync(int current, int dailyLimit, int monthlyTotal)
    {
        var summary = new UsageSummary(current, dailyLimit, monthlyTotal);
        await _repository.AddAsync(summary);
        return summary;
    }

    public async Task UpdateAsync(UsageSummary summary, int current, int dailyLimit, int monthlyTotal)
    {
        summary.Update(current, dailyLimit, monthlyTotal);
        await _repository.UpdateAsync(summary);
    }
}