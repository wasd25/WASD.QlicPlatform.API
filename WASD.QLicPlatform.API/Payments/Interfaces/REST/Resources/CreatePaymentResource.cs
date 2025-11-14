namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(int Id, decimal Amount, System.DateTime Date, string Status, string MethodId);