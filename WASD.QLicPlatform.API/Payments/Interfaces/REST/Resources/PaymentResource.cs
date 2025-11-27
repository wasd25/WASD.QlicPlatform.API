namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    decimal Amount,
    DateTime Date,
    string Status,
    int MethodId
);
