using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;

namespace WASD.QLicPlatform.API.Usage_Management.Application.QueryServices;

public class UsageSummaryQueryService(IUsageSummaryRepository repository) : IUsageSummaryQueryService
{
    public async Task<IEnumerable<UsageSummary>> Handle(GetUsageSummaryQuery query)
    {
        return await repository.ListAsync();
    }
}