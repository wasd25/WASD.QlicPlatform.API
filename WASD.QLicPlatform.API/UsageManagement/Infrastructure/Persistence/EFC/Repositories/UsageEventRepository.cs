using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WASD.QLicPlatform.API.UsageManagement.Infrastructure.Persistence.EFC.Repositories;

public class UsageEventRepository : IUsageEventRepository
{
    private readonly AppDbContext _context;

    public UsageEventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UsageEvent>> GetAllAsync()
        => await _context.UsageEvents.ToListAsync();

    public async Task<UsageEvent?> GetByIdAsync(Guid id)
        => await _context.UsageEvents.FindAsync(id);

    public async Task AddAsync(UsageEvent usageEvent)
    {
        await _context.UsageEvents.AddAsync(usageEvent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.UsageEvents.FindAsync(id);
        if (entity != null)
        {
            _context.UsageEvents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}