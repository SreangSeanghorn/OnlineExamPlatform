using System;
using OnlineExam.Domain.Entities.Roles;
using OnlineExam.UserService.Domain.Admins;
using OnlineExam.UserService.Domain.Roles;


namespace OnlineExam.Domain.Entities.Users;

public static class RoleStrategyFactory
{
    private static Dictionary<string, IRoleStrategy> _strategies;
    private static IRoleRepository _roleRepository;

    static RoleStrategyFactory()
    {
        _strategies = new Dictionary<string, IRoleStrategy>
        {
            { "Admin", new AdminRoleStrategy() },
            { "Teacher", new TeacherRoleStrategy() },
            { "Candidate", new CandidateRoleStrategy()},
  
        };
    }

    public static IRoleStrategy GetStrategy(Role role)
    {
        if (_strategies.ContainsKey(role.Name))
        {
            return _strategies[role.Name];
        }
        throw new ArgumentException($"No strategy found for role: {role.Name}");
    }
}
