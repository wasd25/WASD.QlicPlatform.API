using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

namespace WASD.QLicPlatform.API.Reports.Domain.Repositories;

public interface IReportRepository
{
    Task AddAsync(Report report);
    Task<IEnumerable<Report>> GetAllAsync();
    Task<Report?> GetByIdAsync(int id);
    Task UpdateAsync(Report report);
    Task DeleteAsync(Report report);
}