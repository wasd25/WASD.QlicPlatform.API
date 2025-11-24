using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Domain.Repositories;

namespace WASD.QLicPlatform.API.Reports.Application.Internal.CommandServices;

public class ReportCommandService
{
    private readonly IReportRepository _repository;

    public ReportCommandService(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<Report> CreateAsync(string title, string description)
    {
        var report = new Report(title, description);
        await _repository.AddAsync(report);
        return report;
    }

    public async Task<Report?> UpdateAsync(int id, string title, string description)
    {
        var report = await _repository.GetByIdAsync(id);
        if (report == null) return null;

        report.Update(title, description);
        await _repository.UpdateAsync(report);
        return report;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var report = await _repository.GetByIdAsync(id);
        if (report == null) return false;

        await _repository.DeleteAsync(report);
        return true;
    }
}