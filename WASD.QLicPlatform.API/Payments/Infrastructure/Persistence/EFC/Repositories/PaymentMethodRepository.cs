using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentMethodRepository(AppDbContext context) 
    : BaseRepository<PaymentMethod>(context), IPaymentMethodRepository
{
    public async Task<PaymentMethod?> FindDefaultAsync()
    {
        return await Context.Set<PaymentMethod>()
            .FirstOrDefaultAsync(pm => pm.IsDefault);
    }

    public async Task<IEnumerable<PaymentMethod>> FindByTypeAsync(string type)
    {
        return await Context.Set<PaymentMethod>()
            .Where(pm => pm.Type == type)
            .ToListAsync();
    }
}

