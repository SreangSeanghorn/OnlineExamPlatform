using System;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.Domain.Entities.Roles;

public interface IRoleStrategy
{
    void HandleRole(User user);
}
