using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.QueryServices;

public class PaymentMethodQueryService(IPaymentMethodRepository paymentMethodRepository) 
    : IPaymentMethodQueryService
{
    public async Task<IEnumerable<PaymentMethod>> Handle(GetAllPaymentMethodsQuery query)
    {
        return await paymentMethodRepository.ListAsync();
    }

    public async Task<PaymentMethod?> Handle(GetPaymentMethodByIdQuery query)
    {
        return await paymentMethodRepository.FindByIdAsync(query.Id);
    }
}

