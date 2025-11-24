using Microsoft.EntityFrameworkCore;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.IAM.Domain.Models;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;

namespace WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<UserAggregate>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<UserAggregate?> FindByUsernameAsync(string username)
    {
        return await Context.Set<UserAggregate>()
            .FirstOrDefaultAsync(u => u.Username == username.ToLower());
    }

    public async Task<UserAggregate?> FindByEmailAsync(string email)
    {
        return await Context.Set<UserAggregate>()
            .FirstOrDefaultAsync(u => u.Email == email.ToLower());
    }

    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        return await Context.Set<UserAggregate>()
            .AnyAsync(u => u.Username == username.ToLower());
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await Context.Set<UserAggregate>()
            .AnyAsync(u => u.Email == email.ToLower());
    }

    public async Task<UserAggregate?> FindByUsernameOrEmailAsync(string usernameOrEmail)
    {
        var normalizedInput = usernameOrEmail.ToLower();
        return await Context.Set<UserAggregate>()
            .FirstOrDefaultAsync(u => u.Username == normalizedInput || u.Email == normalizedInput);
    }
}