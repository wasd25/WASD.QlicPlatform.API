using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> FindByStatusAsync(string status);
    Task<IEnumerable<Payment>> FindByMethodIdAsync(int methodId);
}