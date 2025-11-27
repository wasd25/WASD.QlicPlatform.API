namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdatePaymentCommand(
    int Id,
    decimal Amount,
    DateTime Date,
    string Status,
    int MethodId
);
