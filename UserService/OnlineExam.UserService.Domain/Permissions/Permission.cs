using OnlineExam.UserService.Domain.Core.Primitive;
using OnlineExam.UserService.Domain.RolePermissions;
using OnlineExam.UserService.Domain.Roles;

namespace OnlineExam.UserService.Domain.Permissions;

public class Permission : Entity<Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ICollection<RolePermission> Roles { get; set; } = new List<RolePermission>();
    
    public Permission(string name, string description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }
    public static Permission CreatePermission(string name, string description)
    {
        return new Permission(name, description);
    }
    public static Permission GetPermission(string name)
    {
        return new Permission(name, string.Empty);
    }
    public override bool Equals(object obj)
    {
        if (obj is Permission permission)
        {
            return Name == permission.Name;
        }
        return false;
    }
    
}