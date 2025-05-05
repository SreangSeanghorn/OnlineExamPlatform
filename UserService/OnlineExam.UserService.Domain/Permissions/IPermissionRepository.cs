using OnlineExam.UserService.Domain.Core.Repositories;

namespace OnlineExam.UserService.Domain.Permissions;

public interface IPermissionRepository : IGenericRepository<Permission>
{
    Task<Permission> GetPermissionByNameAsync(string name);
}