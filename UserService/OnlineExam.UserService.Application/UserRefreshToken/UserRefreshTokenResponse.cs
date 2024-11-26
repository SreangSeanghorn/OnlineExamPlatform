using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Application.UserRefreshToken
{
    public record UserRefreshTokenResponse(
        string AccessToken,
        string RefreshToken
    )
    {
        
    }
}