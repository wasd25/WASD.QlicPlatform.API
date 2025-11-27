namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(
    decimal Amount,
    DateTime Date,
    string Status,
    int MethodId
);
