
using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.UserLogin
{
    [HttpStatusCode(404)]
    public class UserNotFoundException(string message) : Exception(message)
    {
    }
}