using WASD.QLicPlatform.API.IAM.Domain.Models;
using WASD.QLicPlatform.API.Shared.Domain.Repositories;

namespace WASD.QLicPlatform.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<UserAggregate>
{
    Task<UserAggregate?> FindByUsernameAsync(string username);
    Task<UserAggregate?> FindByEmailAsync(string email);
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByEmailAsync(string email);
    Task<UserAggregate?> FindByUsernameOrEmailAsync(string usernameOrEmail);
}