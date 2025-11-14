using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.QueryServices;

public class PaymentMethodQueryService(IPaymentMethodRepository repository) : IPaymentMethodQueryService
{
    public async Task<IEnumerable<PaymentMethod>> Handle(GetAllPaymentMethodsQuery query)
        => await repository.ListAsync();

    public async Task<PaymentMethod?> Handle(GetPaymentMethodByIdQuery query)
        => await repository.FindByIdAsync(query.Id);
}