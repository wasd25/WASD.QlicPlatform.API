using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    // añadir métodos específicos si se requieren (p.ej. FindByMethodIdAsync)
}