using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
{
    Task<PaymentMethod?> FindDefaultAsync();
    Task<IEnumerable<PaymentMethod>> FindByTypeAsync(string type);
}

