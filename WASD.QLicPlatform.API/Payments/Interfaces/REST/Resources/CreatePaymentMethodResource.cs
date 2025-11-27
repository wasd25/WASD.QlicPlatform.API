namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentMethodResource(
    string Type,
    string Details,
    bool IsDefault
);

