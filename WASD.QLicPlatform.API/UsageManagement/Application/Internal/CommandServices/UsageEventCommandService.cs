using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

namespace WASD.QLicPlatform.API.UsageManagement.Application.Internal.CommandServices;

public class UsageEventCommandService
{
    private readonly IUsageEventRepository _repository;

    public UsageEventCommandService(IUsageEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<UsageEvent> RegisterAsync(DateTime time, int amount, string source)
    {
        var usageEvent = new UsageEvent(time, amount, source);
        await _repository.AddAsync(usageEvent);
        return usageEvent;
    }
}