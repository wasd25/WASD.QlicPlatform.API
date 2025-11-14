using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;

namespace WASD.QLicPlatform.API.UsageManagement.Application.Internal.QueryServices;

public class UsageEventQueryService
{
    private readonly IUsageEventRepository _repository;

    public UsageEventQueryService(IUsageEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UsageEventDto>> GetAllAsync()
    {
        var events = await _repository.GetAllAsync();

        return events.Select(e => new UsageEventDto
        {
            Id = e.Id.ToString(),
            Time = e.Time.ToString("HH:mm"),
            Amount = e.Amount,
            Source = e.Source
        });
    }

    public async Task<UsageEventDto?> GetByIdAsync(Guid id)
    {
        var e = await _repository.GetByIdAsync(id);
        if (e == null) return null;

        return new UsageEventDto
        {
            Id = e.Id.ToString(),
            Time = e.Time.ToString("HH:mm"),
            Amount = e.Amount,
            Source = e.Source
        };
    }
}