﻿// WASD.QLicPlatform.API/Anomalies/Infrastructure/Persistence/EFC/Repositories/AnomalyRepository.cs
        using Microsoft.EntityFrameworkCore;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using WASD.QLicPlatform.API.Anomalies.Domain.Model.Aggregate;
        using WASD.QLicPlatform.API.Anomalies.Domain.Repositories;
        using WASD.QLicPlatform.API.Shared.Domain.Enums;
        using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
        using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
        
        namespace WASD.QLicPlatform.API.Anomalies.Infrastructure.Persistence.EFC.Repositories
        {
            public sealed class AnomalyRepository : BaseRepository<Anomaly>, IAnomalyRepository
            {
                public AnomalyRepository(AppDbContext context) : base(context) { }
        
                public async Task<Anomaly?> GetByIdAsync(Guid id) =>
                    await Context.Set<Anomaly>().FindAsync(id);
        
                public new async Task AddAsync(Anomaly anomaly)
                {
                    await Context.Set<Anomaly>().AddAsync(anomaly);
                    await Context.SaveChangesAsync();
                }
        
                public async Task UpdateAsync(Anomaly anomaly)
                {
                    Context.Set<Anomaly>().Update(anomaly);
                    await Context.SaveChangesAsync();
                }
        
                public async Task DeleteAsync(Guid id)
                {
                    var entity = await Context.Set<Anomaly>().FindAsync(id);
                    if (entity is null) return;
                    Context.Set<Anomaly>().Remove(entity);
                    await Context.SaveChangesAsync();
                }
        
                public async Task<IReadOnlyList<Anomaly>> GetAllAsync(
                    int? profileId,
                    DateTime? from,
                    DateTime? to,
                    int? page,
                    int? pageSize)
                {
                    var query = Context.Set<Anomaly>().AsQueryable();
        
                    if (profileId.HasValue)
                        query = query.Where(a => a.ProfileId == profileId.Value);
                    if (from.HasValue)
                        query = query.Where(a => a.DetectedAt >= from.Value);
                    if (to.HasValue)
                        query = query.Where(a => a.DetectedAt <= to.Value);
        
                    if (page.HasValue && pageSize.HasValue)
                    {
                        var p = Math.Max(1, page.Value);
                        var s = Math.Clamp(pageSize.Value, 10, 200);
                        query = query.Skip((p - 1) * s).Take(s);
                    }
        
                    return await query
                        .OrderByDescending(a => a.DetectedAt)
                        .ToListAsync();
                }
        
                public async Task<IReadOnlyList<Anomaly>> GetByStatusAsync(
                    AnomalyStatus status,
                    int? profileId,
                    DateTime? from,
                    DateTime? to,
                    int? page,
                    int? pageSize)
                {
                    var query = Context.Set<Anomaly>().Where(a => a.Status == status);
        
                    if (profileId.HasValue)
                        query = query.Where(a => a.ProfileId == profileId.Value);
                    if (from.HasValue)
                        query = query.Where(a => a.DetectedAt >= from.Value);
                    if (to.HasValue)
                        query = query.Where(a => a.DetectedAt <= to.Value);
        
                    if (page.HasValue && pageSize.HasValue)
                    {
                        var p = Math.Max(1, page.Value);
                        var s = Math.Clamp(pageSize.Value, 10, 200);
                        query = query.Skip((p - 1) * s).Take(s);
                    }
        
                    return await query
                        .OrderByDescending(a => a.DetectedAt)
                        .ToListAsync();
                }
        
                public async Task<IReadOnlyList<(DateTime Date, int Count)>> GetTrendAsync(
                    DateTime from,
                    DateTime to,
                    int? profileId)
                {
                    var query = Context.Set<Anomaly>()
                        .Where(a => a.DetectedAt >= from && a.DetectedAt <= to);
        
                    if (profileId.HasValue)
                        query = query.Where(a => a.ProfileId == profileId.Value);
        
                    var trend = await query
                        .GroupBy(a => a.DetectedAt.Date)
                        .Select(g => new { Date = g.Key, Count = g.Count() })
                        .OrderBy(x => x.Date)
                        .ToListAsync();
        
                    return trend.Select(x => (x.Date, x.Count)).ToList();
                }
            }
        }