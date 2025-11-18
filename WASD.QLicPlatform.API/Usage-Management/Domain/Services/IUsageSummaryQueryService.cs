using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Services;

public interface IUsageSummaryQueryService
{
    Task<IEnumerable<UsageSummary>> Handle(GetUsageSummaryQuery query);
}