using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
{
    Task<PaymentMethod?> FindDefaultAsync();
    Task ClearDefaultExceptAsync(int keepId);
}