using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
    Task<Payment?> Handle(GetPaymentByIdQuery query);
}