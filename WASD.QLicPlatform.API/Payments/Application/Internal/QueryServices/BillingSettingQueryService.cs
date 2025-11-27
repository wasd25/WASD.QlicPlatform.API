using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;
using WASD.QLicPlatform.API.Payments.Domain.Repositories;
using WASD.QLicPlatform.API.Payments.Domain.Services;

namespace WASD.QLicPlatform.API.Payments.Application.Internal.QueryServices;

public class BillingSettingQueryService(IBillingSettingRepository billingSettingRepository) 
    : IBillingSettingQueryService
{
    public async Task<BillingSetting?> Handle(GetBillingSettingQuery query)
    {
        // Get the first (and only) billing setting record
        var allSettings = await billingSettingRepository.ListAsync();
        return allSettings.FirstOrDefault();
    }
}

