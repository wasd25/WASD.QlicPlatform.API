using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository repository) : IPaymentQueryService
{
    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }
}