using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IPaymentMethodCommandService
{
    Task<PaymentMethod?> Handle(CreatePaymentMethodCommand command);
    Task<PaymentMethod?> Handle(UpdatePaymentMethodCommand command);
    Task<PaymentMethod?> Handle(DeletePaymentMethodCommand command);
}