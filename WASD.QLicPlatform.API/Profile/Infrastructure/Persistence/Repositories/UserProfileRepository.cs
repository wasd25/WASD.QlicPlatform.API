using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Profile.Domain.Models;
using WASD.QLicPlatform.API.Profile.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WASD.QLicPlatform.API.Profile.Infrastructure.Persistence.Repositories;

public class UserProfileRepository : BaseRepository<UserProfileAggregate>, IUserProfileRepository
{
    public UserProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<UserProfileAggregate?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<UserProfileAggregate>()
            .FirstOrDefaultAsync(p => p.Id == userId);
    }

    public async Task<bool> ExistsByUserIdAsync(int userId)
    {
        return await Context.Set<UserProfileAggregate>()
            .AnyAsync(p => p.Id == userId);
    }
}