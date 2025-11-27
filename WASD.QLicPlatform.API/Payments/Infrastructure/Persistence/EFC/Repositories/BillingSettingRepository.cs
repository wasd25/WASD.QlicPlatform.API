using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class BillingSettingRepository(AppDbContext context) 
    : BaseRepository<BillingSetting>(context), IBillingSettingRepository
{
    public async Task<BillingSetting?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<BillingSetting>()
            .FirstOrDefaultAsync(bs => bs.UserId == userId);
    }
}

