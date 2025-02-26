using OnlineExam.Domain.Entities.Roles;
using OnlineExam.UserService.Domain.Roles;

namespace OnlineExam.UserService.Domain.Users;

public class UserRoleStrategy : IRoleStrategy
{
    public void HandleRole(User user)
    {
        user.AssignRole(Role.GetRole("User"));
    }
}