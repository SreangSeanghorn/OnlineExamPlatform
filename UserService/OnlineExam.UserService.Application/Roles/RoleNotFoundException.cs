using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.Roles;

[HttpStatusCode(404)]
public class RoleNotFoundException : Exception
{
    public RoleNotFoundException(string message) : base(message)
    {
    }
    
    public RoleNotFoundException() : base("Role not found")
    {
    }
}