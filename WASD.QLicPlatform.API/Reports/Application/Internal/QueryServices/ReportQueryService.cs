using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Domain.Repositories;

namespace WASD.QLicPlatform.API.Reports.Application.Internal.QueryServices;

public class ReportQueryService
{
    private readonly IReportRepository _repository;

    public ReportQueryService(IReportRepository repository)
    {
        _repository = repository; 
    }

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Report?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}