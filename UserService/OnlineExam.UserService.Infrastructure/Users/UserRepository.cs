using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Commons;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;

namespace OnlineExam.UserService.Infrastructure.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<User> GetUserAndUserRoleByEmail(string email)
        {
            return await _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public Task<User> LoginUserAsync(string email, string password)
        {
            return _context.Set<User>().FirstOrDefaultAsync(u => u.Email.Value == email && u.Password == password);
        }

        public Task<User> GetUserByEmailWithRolesAsync(string email)
        {
            return _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<User> GetUserByRefreshToken(string token)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
            
        }
        public async Task<User> GetUserByIdWithRolesAsync(Guid id)
        {
            return await _context.Set<User>().Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserAndUserRoleWithPermissionsByUsername(string username)
        {
            return await _context.Set<User>()
                .Include(u => u.Roles)
                .ThenInclude(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}