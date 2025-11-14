using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class PaymentMethodAssemblers
{
    public static CreatePaymentMethodCommand ToCommand(this CreatePaymentMethodResource r) =>
        new(r.Id, r.Type, r.Details, r.IsDefault);

    public static UpdatePaymentMethodCommand ToCommand(this UpdatePaymentMethodResource r) =>
        new(r.Id, r.Type, r.Details, r.IsDefault);

    public static PaymentMethodResource ToResource(this PaymentMethod e) =>
        new(e.Id, e.Type, e.Details, e.IsDefault);
}