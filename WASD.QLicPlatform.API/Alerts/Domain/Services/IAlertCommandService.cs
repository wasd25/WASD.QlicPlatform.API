using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;

namespace WASD.QLicPlatform.API.Alerts.Domain.Services;

public interface IAlertCommandService
{
    public Task<Alert?> Handle(CreateAlertCommand command);
    public Task<Alert?> Handle(DeleteAlertCommand command);
    public Task<Alert?> Handle(UpdateAlertCommand command);
}