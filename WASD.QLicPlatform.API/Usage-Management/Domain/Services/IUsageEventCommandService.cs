using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Usage_Management.Domain.Services;

public interface IUsageEventCommandService
{
    public Task<UsageEvents?> Handle(CreateUsageEventCommand command);
    public Task<UsageEvents?> Handle(DeleteUsageEventCommand command);
    public Task<UsageEvents?> Handle(UpdateUsageEventCommand command);
}