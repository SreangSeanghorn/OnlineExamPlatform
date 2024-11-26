using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Application.UserRegistered
{
    public record RegisterRequest(
        string Username, string Email, string Password);
}