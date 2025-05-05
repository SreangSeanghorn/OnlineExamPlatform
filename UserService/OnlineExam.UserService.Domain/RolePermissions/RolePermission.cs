using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Domain.Roles;

namespace OnlineExam.UserService.Domain.RolePermissions;

public class RolePermission
{
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }
    public Guid PermissionId { get; private set; }
    public Permission Permission { get; private set; }
    
    public static RolePermission createRolePermission(Guid roleId, Guid permissionId)
    {
        return new RolePermission
        {
            RoleId = roleId,
            PermissionId = permissionId
        };
    }
}