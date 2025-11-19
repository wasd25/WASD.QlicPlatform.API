using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;

namespace WASD.QLicPlatform.API.Usage_Management.Application.QueryServices;

public class UsageEventsQueryService(IUsageEventsRepository repository) : IUsageEventQueryService
{
    public async Task<IEnumerable<UsageEvents>> Handle(GetAllUsageEventsQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<UsageEvents?> Handle(GetUsageEventByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }
}