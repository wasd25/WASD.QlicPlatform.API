using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Repositories;
using WASD.QLicPlatform.API.Alerts.Services;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Alerts.Application.Internal.CommandServices;

public class AlertCommandService(IAlertRepository repository, IUnitOfWork unitOfWork) : IAlertCommandService
{
    public async Task<Alert?> Handle(CreateAlertCommand command)
    {
        var alert = new Alert(command);
        await repository.AddAsync(alert);
        await unitOfWork.CompleteAsync();
        return alert;
    }

    public async Task<Alert?> Handle(DeleteAlertCommand command)
    {
        var alert = await repository.FindByIdAsync(command.AlertId);

        if (alert == null)
            throw new ArgumentException("Alert not found");

        try
        {
            repository.Update(alert);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to update order {command.AlertId}", e);
        }
        
        return alert;
    }

    public async Task<Alert?> Handle(UpdateAlertCommand command)
    {
        var alert = await repository.FindByIdAsync(command.AlertId);
        
        if (alert == null)
            throw new ArgumentException("Alert not found");

        try
        {
            repository.Remove(alert);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to delete order {command.AlertId}", e);
        }
        
        return alert;
    }
}