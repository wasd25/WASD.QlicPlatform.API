using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IBillingSettingRepository : IBaseRepository<BillingSetting>
{
    Task<BillingSetting?> FindByUserIdAsync(int userId);
}

