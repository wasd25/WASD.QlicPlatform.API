using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace WASD.QLicPlatform.API.UsageManagement.Infrastructure.Persistence.EFC.Repositories;

public class UsageSummaryRepository : IUsageSummaryRepository
{
    private readonly AppDbContext _context;

    public UsageSummaryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UsageSummary?> GetAsync()
        => await _context.UsageSummaries.FirstOrDefaultAsync();

    public async Task AddAsync(UsageSummary summary)
    {
        await _context.UsageSummaries.AddAsync(summary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UsageSummary summary)
    {
        _context.UsageSummaries.Update(summary);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.UsageSummaries.FindAsync(id);
        if (entity != null)
        {
            _context.UsageSummaries.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}