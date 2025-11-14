using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

namespace WASD.QLicPlatform.API.UsageManagement.Application.Internal.QueryServices;

public class UsageSummaryQueryService
{
    private readonly IUsageSummaryRepository _repository;

    public UsageSummaryQueryService(IUsageSummaryRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsageSummaryDto?> GetAsync()
    {
        var summary = await _repository.GetAsync();
        if (summary == null) return null;

        return new UsageSummaryDto
        {
            Current = summary.Current,
            DailyLimit = summary.DailyLimit,
            MonthlyTotal = summary.MonthlyTotal
        };
    }
}