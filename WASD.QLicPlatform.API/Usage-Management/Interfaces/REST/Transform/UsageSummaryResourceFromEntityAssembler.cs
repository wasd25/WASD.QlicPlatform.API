using WASD.QLicPlatform.API.Usage_Management.Domain.Model.Aggregate;
using WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Resources;

namespace WASD.QLicPlatform.API.Usage_Management.Interfaces.REST.Transform;

public class UsageSummaryResourceFromEntityAssembler
{
    public static UsageSummaryResource ToResourceFromEntity(UsageSummary usageSummary)
    {
        return new UsageSummaryResource(
            usageSummary.Id,
            usageSummary.Current,
            usageSummary.DailyLimit,
            usageSummary.MonthlyTotal);
    }
}