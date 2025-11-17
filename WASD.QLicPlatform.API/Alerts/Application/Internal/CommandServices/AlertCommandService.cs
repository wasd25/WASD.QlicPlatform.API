using WASD.QLicPlatform.API.Alerts.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Alerts.Domain.Model.Commands;
using WASD.QLicPlatform.API.Alerts.Domain.Repositories;
using WASD.QLicPlatform.API.Alerts.Domain.Services;
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
            return null; 

        try
        {
            repository.Remove(alert); 
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to delete alert {command.AlertId}", e);
        }

        return alert;
    }

    public async Task<Alert?> Handle(UpdateAlertCommand command)
    {
        var alert = await repository.FindByIdAsync(command.AlertId);

        if (alert == null) return null;
        
        alert.Update(command.Type, command.Title, command.Message, command.Timestamp);
        
        repository.Update(alert);
        
        await unitOfWork.CompleteAsync();
        return alert;
    }
}