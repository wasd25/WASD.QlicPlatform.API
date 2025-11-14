namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record UpdatePaymentMethodCommand(int Id, string Type, string Details, bool IsDefault);