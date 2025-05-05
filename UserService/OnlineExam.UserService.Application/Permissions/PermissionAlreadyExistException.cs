using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.Permissions;

[HttpStatusCode(403)]
public class PermissionAlreadyExistException : Exception
{
    public PermissionAlreadyExistException(string message) : base(message)
    {
    }
}
