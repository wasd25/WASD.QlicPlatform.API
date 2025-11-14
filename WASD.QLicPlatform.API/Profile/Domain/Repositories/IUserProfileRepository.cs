using WASD.QLicPlatform.API.Profile.Domain.Models;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.Profile.Domain.Repositories;

public interface IUserProfileRepository : IBaseRepository<UserProfileAggregate>
{
    Task<UserProfileAggregate?> FindByUserIdAsync(int userId);
    Task<bool> ExistsByUserIdAsync(int userId);
}