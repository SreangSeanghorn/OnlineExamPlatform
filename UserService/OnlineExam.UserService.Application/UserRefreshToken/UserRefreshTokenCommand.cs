using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.UserRefreshToken
{
    public record UserRefreshTokenCommand (
        string refreshToken
    ): ICommand<BaseResponse<UserRefreshTokenResponse>>
    {
        
    }
}