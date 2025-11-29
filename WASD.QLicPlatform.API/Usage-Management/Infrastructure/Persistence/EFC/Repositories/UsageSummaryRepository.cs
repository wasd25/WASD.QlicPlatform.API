using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;

namespace WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Repositories;

public class UsageSummaryRepository(AppDbContext context)
    : BaseRepository<UsageSummary>(context), IUsageSummaryRepository
{
    public new async Task<UsageSummary?> FindByIdAsync(int id)
    {
        return await Context.Set<UsageSummary>().FirstOrDefaultAsync(u => u.Id == id);
    }
}