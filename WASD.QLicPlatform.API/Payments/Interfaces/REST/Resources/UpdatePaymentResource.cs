namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record UpdatePaymentResource(
    decimal Amount,
    DateTime Date,
    string Status,
    int MethodId
);
