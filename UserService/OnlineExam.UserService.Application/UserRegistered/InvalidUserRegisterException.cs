using System;

namespace OnlineExam.UserService.Application.UserRegistered
{
    public class InvalidUserRegisterException : Exception
    {
        public InvalidUserRegisterException(string message) : base(message)
        {
        }

    }

}


