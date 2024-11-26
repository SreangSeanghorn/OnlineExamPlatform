using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.UserRefreshToken
{
    public class UserRefreshTokenCommandHandler : ICommandHandler<UserRefreshTokenCommand, BaseResponse<UserRefreshTokenResponse>>
    {
        private readonly UserRefreshTokenService _userRefreshTokenService;

        public UserRefreshTokenCommandHandler(UserRefreshTokenService userRefreshTokenService)
        {
            _userRefreshTokenService = userRefreshTokenService;
        }
        public Task<BaseResponse<UserRefreshTokenResponse>> Handle(UserRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = _userRefreshTokenService.RefreshToken(request.refreshToken);
            if(response == null)
            {
                return Task.FromResult(new BaseResponse<UserRefreshTokenResponse>(
                    false,
                    401,
                    "Invalid token.",
                    null
                ));
            }
            return Task.FromResult(new BaseResponse<UserRefreshTokenResponse>(
                true,
                200,
                "Token refreshed successfully.",
                response.Result
            ));
        }
    }
}