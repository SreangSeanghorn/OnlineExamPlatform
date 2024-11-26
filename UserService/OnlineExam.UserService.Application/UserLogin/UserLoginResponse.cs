using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Application.UserLogin
{
    public record UserLoginResponse(
        string Token,
        string RefreshToken,
        DateTime ExpiresIn
    );
}