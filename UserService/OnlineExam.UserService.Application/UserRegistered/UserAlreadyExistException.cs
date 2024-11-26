using System;
using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.UserRegistered
{
    [HttpStatusCode(409)]
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string message) : base(message)
        {
        }

    }
}

