namespace WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

public record CreatePaymentMethodCommand(int Id, string Type, string Details, bool IsDefault);