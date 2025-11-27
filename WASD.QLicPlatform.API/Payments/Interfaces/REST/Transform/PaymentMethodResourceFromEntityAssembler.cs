using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class PaymentMethodResourceFromEntityAssembler
{
    public static PaymentMethodResource ToResourceFromEntity(PaymentMethod entity)
    {
        return new PaymentMethodResource(
            entity.Id,
            entity.Type,
            entity.Details,
            entity.IsDefault
        );
    }
}

