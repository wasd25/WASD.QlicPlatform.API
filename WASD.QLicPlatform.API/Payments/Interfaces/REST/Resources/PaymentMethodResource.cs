namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record PaymentMethodResource(int Id, string Type, string Details, bool IsDefault);