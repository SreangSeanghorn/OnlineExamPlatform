using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Entities;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Infrastructure.Commons;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;

namespace OnlineExam.UserService.Infrastructure.Roles
{
    public class RoleRepositoy : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepositoy(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Role> GetDefaultRole()
        {
            return _context.Set<Role>().FirstOrDefaultAsync(r => r.Name == "User");
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}