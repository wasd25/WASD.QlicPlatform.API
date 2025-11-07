using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Queries;

namespace WASD.QLicPlatform.API.Alerts.Services;

public interface IAlertQueryService
{
    Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query);
    Task<Alert?> Handle(GetAlertByIdQuery query);
}