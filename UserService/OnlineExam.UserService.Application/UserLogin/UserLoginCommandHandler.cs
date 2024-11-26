using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.UserLogin
{
    public class UserLoginCommandHandler: ICommandHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>
    {
        private readonly UserLoginService _userLoginService;

        public UserLoginCommandHandler(UserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        public async Task<BaseResponse<UserLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userLoginService.GetUserByNameAsync(request.Username);
            if(user == null) {
                throw new Exception("User not found");
            }
            var response = await _userLoginService.LoginUserAsync(request.Username, request.Password);
            if(response == null) {
                throw new Exception("Invalid password");
            }
            var baseResponse = new BaseResponse<UserLoginResponse>(
                true,
                200,
                "Login successful",
                response
            );
            return baseResponse;

        }
    }
}