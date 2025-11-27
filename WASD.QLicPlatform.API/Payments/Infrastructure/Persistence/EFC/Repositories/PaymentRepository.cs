using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext context) 
    : BaseRepository<Payment>(context), IPaymentRepository
{
    public async Task<IEnumerable<Payment>> FindByStatusAsync(string status)
    {
        return await Context.Set<Payment>()
            .Where(p => p.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> FindByMethodIdAsync(int methodId)
    {
        return await Context.Set<Payment>()
            .Where(p => p.MethodId == methodId)
            .ToListAsync();
    }
}