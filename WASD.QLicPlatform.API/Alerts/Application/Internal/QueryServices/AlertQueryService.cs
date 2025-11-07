using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Queries;
using WASD.QLicPlatform.API.Alerts.Repositories;
using WASD.QLicPlatform.API.Alerts.Services;

namespace WASD.QLicPlatform.API.Alerts.Application.Internal.QueryServices;

public class AlertQueryService(IAlertRepository repository) : IAlertQueryService
{
    public async Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<Alert?> Handle(GetAlertByIdQuery query)
    {
        return await repository.FindByIdAsync((int)query.Id);
    }
}