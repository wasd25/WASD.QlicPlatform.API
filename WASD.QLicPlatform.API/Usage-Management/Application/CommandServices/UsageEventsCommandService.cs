using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;

namespace WASD.QLicPlatform.API.Usage_Management.Application.CommandServices;

public class UsageEventsCommandService(IUsageEventsRepository repository, IUnitOfWork unitOfWork) : IUsageEventCommandService
{
    public async Task<UsageEvents?> Handle(CreateUsageEventCommand command)
    {
        var usageEvent = new UsageEvents(command);
        await repository.AddAsync(usageEvent);
        await unitOfWork.CompleteAsync();
        return usageEvent;
    }

    public async Task<UsageEvents?> Handle(DeleteUsageEventCommand command)
    {
        var usageEvent = await repository.FindByIdAsync(command.UsageEventId);
        if (usageEvent == null)
            return null;

        try
        {
            repository.Remove(usageEvent);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to delete usage event {command.UsageEventId}", e);
        }
        
        return usageEvent;
    }

    public async Task<UsageEvents?> Handle(UpdateUsageEventCommand command)
    {
        var usageEvent = await repository.FindByIdAsync(command.UsageEventId);
        if (usageEvent == null)
            return null;
        
        usageEvent.Update(command.Time, command.Amount, command.Source);
        
        repository.Update(usageEvent);
        
        await unitOfWork.CompleteAsync();
        return usageEvent;
    }
}