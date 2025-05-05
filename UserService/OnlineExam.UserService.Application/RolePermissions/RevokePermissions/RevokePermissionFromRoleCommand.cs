using OnlineExam.UserService.Application.Shared.Commands;

namespace OnlineExam.UserService.Application.RolePermissions.RevokePermissions;

public record RevokePermissionFromRoleCommand(Guid RoleId, Guid PermissionId) : ICommand;