using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Repositories;

namespace OnlineExam.UserService.Domain.Roles
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetDefaultRole();
        Task<Role> GetRoleByNameAsync(string roleName);
        
    }
}