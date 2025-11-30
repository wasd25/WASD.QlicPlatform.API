using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class UpdatePaymentMethodCommandFromResourceAssembler
{
    public static UpdatePaymentMethodCommand ToCommandFromResource(int id, UpdatePaymentMethodResource resource)
    {
        return new UpdatePaymentMethodCommand(
            id,
            resource.IsDefault
        );
    }
}

