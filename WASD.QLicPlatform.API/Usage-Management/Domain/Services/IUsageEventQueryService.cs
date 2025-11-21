using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Services;

public interface IUsageEventQueryService
{
    Task<IEnumerable<UsageEvents>> Handle(GetAllUsageEventsQuery query);
    Task<UsageEvents?> Handle(GetUsageEventByIdQuery query);
}