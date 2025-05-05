namespace OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;

public record AssignPermissionToRoleRequestDto(
    Guid RoleId,
    Guid PermissionId
);