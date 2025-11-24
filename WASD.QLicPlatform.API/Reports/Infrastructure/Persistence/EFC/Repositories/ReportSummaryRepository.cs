using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class ReportSummaryRepository : BaseRepository<ReportSummary>
{
    public ReportSummaryRepository(AppDbContext context) : base(context) { }
}
