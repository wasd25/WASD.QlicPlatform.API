using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;
using WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Transform;

public static class UpdatePaymentCommandFromResourceAssembler
{
    public static UpdatePaymentCommand ToCommandFromResource(int id, UpdatePaymentResource resource)
    {
        return new UpdatePaymentCommand(
            id,
            resource.Amount,
            resource.Date,
            resource.Status,
            resource.MethodId
        );
    }
}