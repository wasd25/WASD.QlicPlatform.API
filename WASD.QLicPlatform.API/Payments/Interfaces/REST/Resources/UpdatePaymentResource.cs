namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record UpdatePaymentResource(int Id, decimal Amount, System.DateTime Date, string Status, string MethodId);