using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;

namespace WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Repositories;

public class UsageEventsRepository(AppDbContext context)
    : BaseRepository<UsageEvents>(context), IUsageEventsRepository
{
    public async Task<IEnumerable<UsageEvents>> findBySourceAsync(string source)
    {
        return await Context.Set<UsageEvents>().Where(u => u.Source == source).ToListAsync();
    }
    public new async Task<UsageEvents?> FindByIdAsync(int id)
    {
        return await Context.Set<UsageEvents>().FirstOrDefaultAsync(u => u.Id == id);
    }
}