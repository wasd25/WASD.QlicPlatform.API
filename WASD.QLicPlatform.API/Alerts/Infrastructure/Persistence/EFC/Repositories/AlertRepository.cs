using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Alerts.Infrastructure.Persistence.EFC.Repositories;

public class AlertRepository(AppDbContext context)
    : BaseRepository<Alert>(context), IAlertRepository
{
    public async Task<IEnumerable<Alert>> findByTitleAsync(string title)
    {
        return await Context.Set<Alert>().Where(p => p.Title == title).ToListAsync();
    }
    
    public async Task<Alert?> FindByIdAsync(int id)
    {
        return await Context.Set<Alert>().FirstOrDefaultAsync(p => p.Id == id);
    }
}