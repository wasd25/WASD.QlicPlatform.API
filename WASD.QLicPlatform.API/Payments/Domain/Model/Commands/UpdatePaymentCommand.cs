namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdatePaymentCommand(int Id, decimal Amount, System.DateTime Date, string Status, string MethodId);