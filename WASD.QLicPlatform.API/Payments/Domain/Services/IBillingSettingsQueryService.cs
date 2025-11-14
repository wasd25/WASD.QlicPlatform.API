using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IBillingSettingsQueryService
{
    Task<BillingSettings?> Handle(GetSingletonBillingSettingsQuery query);
    Task<BillingSettings?> Handle(GetBillingSettingsByIdQuery query);
}