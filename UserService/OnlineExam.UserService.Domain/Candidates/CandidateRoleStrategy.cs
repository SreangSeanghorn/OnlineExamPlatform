using System;
using OnlineExam.Domain.Entities.Roles;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Domain.Admins;


public class CandidateRoleStrategy : IRoleStrategy
{
    public void HandleRole(User user)
    {
        // user.AssignRole(Role.GetRole("Candidate"));
        user.RaiseRoleAssignedEvent("Candidate");
    }

}
