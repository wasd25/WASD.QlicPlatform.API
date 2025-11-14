using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.QueryServices;

public class BillingSettingsQueryService(IBillingSettingsRepository repository)
    : IBillingSettingsQueryService
{
    public async Task<BillingSettings?> Handle(GetSingletonBillingSettingsQuery query)
        => await repository.GetSingletonAsync();

    public async Task<BillingSettings?> Handle(GetBillingSettingsByIdQuery query)
        => await repository.FindByIdAsync(query.Id);
}