using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IPaymentMethodQueryService
{
    Task<IEnumerable<PaymentMethod>> Handle(GetAllPaymentMethodsQuery query);
    Task<PaymentMethod?> Handle(GetPaymentMethodByIdQuery query);
}

