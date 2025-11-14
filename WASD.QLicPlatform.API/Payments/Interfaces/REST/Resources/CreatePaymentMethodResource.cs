namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentMethodResource(int Id, string Type, string Details, bool IsDefault);
