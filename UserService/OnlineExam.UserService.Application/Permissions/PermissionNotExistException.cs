using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.Permissions;
[HttpStatusCode(404)]
public class PermissionNotExistException : Exception
{
    public PermissionNotExistException(Guid permissionId) : base($"Permission with ID '{permissionId}' does not exist.")
    {
    }
}