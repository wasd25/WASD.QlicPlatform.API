using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IBillingSettingCommandService
{
    Task<BillingSetting?> Handle(UpdateBillingSettingCommand command);
}

