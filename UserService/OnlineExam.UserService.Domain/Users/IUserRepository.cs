using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using OnlineExam.UserService.Domain.Core.Repositories;

namespace OnlineExam.UserService.Domain.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public  Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByUsernameAsync(string username);
        public Task<User> LoginUserAsync(string email, string password);

        public Task<User> GetUserByEmailWithRolesAsync(string email);
        public Task<User> GetUserByRefreshToken(string token);
        public Task<User> GetUserByIdWithRolesAsync(Guid id);
        public Task<User> GetUserAndUserRoleWithPermissionsByUsername(string username);
    }
}