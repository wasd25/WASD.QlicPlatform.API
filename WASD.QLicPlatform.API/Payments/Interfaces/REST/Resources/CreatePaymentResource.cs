namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(
    decimal Amount,
    DateTime Date,
    string Status,
    int MethodId
);
