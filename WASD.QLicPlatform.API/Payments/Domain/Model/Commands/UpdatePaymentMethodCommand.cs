namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdatePaymentMethodCommand(
    int Id,
    bool IsDefault
);


