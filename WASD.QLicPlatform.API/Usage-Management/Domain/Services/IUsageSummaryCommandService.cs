using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Services;

public interface IUsageSummaryCommandService
{
    public Task<UsageSummary?> Handle(UpdateUsageSummaryCommand command);
}