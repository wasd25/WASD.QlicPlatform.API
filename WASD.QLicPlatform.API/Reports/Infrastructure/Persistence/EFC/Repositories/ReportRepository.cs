using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;
using WASD.QLicPlatform.API.Reports.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration; // 👈 Aquí está AppDbContext

namespace WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Report report)
    {
        await _context.Set<Report>().AddAsync(report);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _context.Set<Report>().ToListAsync();
    }

    public async Task<Report?> GetByIdAsync(int id)
    {
        return await _context.Set<Report>().FindAsync(id);
    }

    public async Task UpdateAsync(Report report)
    {
        _context.Set<Report>().Update(report);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Report report)
    {
        _context.Set<Report>().Remove(report);
        await _context.SaveChangesAsync();
    }
}