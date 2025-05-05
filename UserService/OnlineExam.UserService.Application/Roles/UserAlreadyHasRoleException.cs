using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.Roles;

[HttpStatusCode(409)]
public class UserAlreadyHasRoleException : Exception
{
    public  UserAlreadyHasRoleException(string message) : base(message)
    {
        
        
    }
    
    
}