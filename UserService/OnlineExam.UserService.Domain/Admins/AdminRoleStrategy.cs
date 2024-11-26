using System;
using OnlineExam.Domain.Entities.Roles;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Domain.Admins;


public class AdminRoleStrategy : IRoleStrategy
{
    public void HandleRole(User user)
    {
        user.AssignRole(Role.GetRole("Admin"));
    }

}
