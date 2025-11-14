using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command);
    Task<Payment?> Handle(UpdatePaymentCommand command);
}