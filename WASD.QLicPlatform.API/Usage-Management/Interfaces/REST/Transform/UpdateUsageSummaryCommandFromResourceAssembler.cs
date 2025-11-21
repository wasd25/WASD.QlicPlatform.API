using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Commands;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class UpdateUsageSummaryCommandFromResourceAssembler
{
    public static UpdateUsageSummaryCommand ToCommandFromResource(int id, UpdateUsageSummaryResource resource)
    {
        return new UpdateUsageSummaryCommand(
            id,
            resource.Current,
            resource.DailyLimit,
            resource.MonthlyTotal);
    }
}