using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IPaymentMethodCommandService
{
    Task<PaymentMethod?> Handle(CreatePaymentMethodCommand command);
    Task<PaymentMethod?> Handle(UpdatePaymentMethodCommand command);
    Task<bool> Handle(DeletePaymentMethodCommand command);
}

