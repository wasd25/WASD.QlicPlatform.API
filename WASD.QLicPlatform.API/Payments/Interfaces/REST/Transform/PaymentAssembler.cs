using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class PaymentAssemblers
{
    public static CreatePaymentCommand ToCommand(this CreatePaymentResource r) =>
        new CreatePaymentCommand(r.Id, r.Amount, r.Date, r.Status, r.MethodId);

    public static UpdatePaymentCommand ToCommand(this UpdatePaymentResource r) =>
        new UpdatePaymentCommand(r.Id, r.Amount, r.Date, r.Status, r.MethodId);

    public static PaymentResource ToResource(this Payment p) =>
        new PaymentResource(p.Id, p.Amount, p.Date, p.Status, p.MethodId);
}