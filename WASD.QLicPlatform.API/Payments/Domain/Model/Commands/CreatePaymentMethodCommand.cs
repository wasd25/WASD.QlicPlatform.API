namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record CreatePaymentMethodCommand(
    string Type,
    string Details,
    bool IsDefault
);

