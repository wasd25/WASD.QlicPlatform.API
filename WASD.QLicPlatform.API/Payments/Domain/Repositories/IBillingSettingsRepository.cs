using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IBillingSettingsRepository : IBaseRepository<BillingSettings>
{
    Task<bool> AnyAsync();
    Task<BillingSettings?> GetSingletonAsync();
}