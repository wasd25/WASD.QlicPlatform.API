using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class CreatePaymentMethodCommandFromResourceAssembler
{
    public static CreatePaymentMethodCommand ToCommandFromResource(CreatePaymentMethodResource resource)
    {
        return new CreatePaymentMethodCommand(
            resource.Type,
            resource.Details,
            resource.IsDefault
        );
    }
}

