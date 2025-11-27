using WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Payments.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Payments.Domain.Services;

public interface IBillingSettingQueryService
{
    Task<BillingSetting?> Handle(GetBillingSettingQuery query);
}

