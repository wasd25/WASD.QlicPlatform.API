namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record UpdatePaymentMethodResource(int Id, string Type, string Details, bool IsDefault);
