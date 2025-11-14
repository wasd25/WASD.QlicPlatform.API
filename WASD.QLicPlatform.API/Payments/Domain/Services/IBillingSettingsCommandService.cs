using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IBillingSettingsCommandService
{
    Task<BillingSettings?> Handle(CreateBillingSettingsCommand command);
    Task<BillingSettings?> Handle(UpdateBillingSettingsCommand command);
}