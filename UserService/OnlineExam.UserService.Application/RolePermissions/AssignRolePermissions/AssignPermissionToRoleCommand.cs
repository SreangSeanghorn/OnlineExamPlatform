using OnlineExam.UserService.Application.Shared.Commands;

namespace OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;

public record AssignPermissionToRoleCommand(
        Guid RoleId,
        Guid PermissionId) : ICommand;