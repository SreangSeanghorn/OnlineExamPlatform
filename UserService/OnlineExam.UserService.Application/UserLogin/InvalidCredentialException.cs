using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Application.Shared.Exception;

namespace OnlineExam.UserService.Application.UserLogin
{
    [HttpStatusCode(401)]
    public class InvalidCredentialException : Exception
    {
        public InvalidCredentialException(string message) : base(message)
        {
        }
        
    }
}