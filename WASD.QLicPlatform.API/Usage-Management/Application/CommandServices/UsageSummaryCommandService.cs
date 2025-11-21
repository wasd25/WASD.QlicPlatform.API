using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;

namespace WASD.QLicPlatform.API.Usage_Management.Application.CommandServices;

public class UsageSummaryCommandService(IUsageSummaryRepository repository, IUnitOfWork unitOfWork) : IUsageSummaryCommandService
{
    public async Task<UsageSummary?> Handle(UpdateUsageSummaryCommand command)
    {
        var usageSummary = await repository.FindByIdAsync(command.UsageSummaryId);

        if (usageSummary == null) return null;
        
        usageSummary.Update(command.Current, command.DailyLimit, command.MonthlyTotal);
        
        repository.Update(usageSummary);

        await unitOfWork.CompleteAsync();
        return usageSummary;
    }
}