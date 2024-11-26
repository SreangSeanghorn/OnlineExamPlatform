using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.UserService.Application.Shared.Resolver;
using OnlineExam.UserService.Application.Shared.Responses;
using OnlineExam.UserService.Application.UserLogin;
using OnlineExam.UserService.Application.UserRefreshToken;
using OnlineExam.UserService.Application.UserRegistered;

namespace OnlineExam.UserService.Application.Authentication
{
    [ApiController]
    [Route("api/user")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICommandResolver _commandResolver;

        public AuthenticationController(ICommandResolver commandResolver)
        {
            _commandResolver = commandResolver;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var command = new UserRegisterCommand(request.Username, request.Email, request.Password);
            var result = await _commandResolver.ResolveHandler<UserRegisterCommand, BaseResponse<UserRegisteredResponse>>(command);
            BaseResponse<UserRegisteredResponse> response = new BaseResponse<UserRegisteredResponse>(
                true,
                200,
                "User Registered Successfully",
                result.Data);
            
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var command = new UserLoginCommand(request.Username, request.Password);
            var result = await _commandResolver.ResolveHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>(command);
            if(result.Data == null){
                return BadRequest(result);
            }
            BaseResponse<UserLoginResponse> response = new BaseResponse<UserLoginResponse>(
                true,
                200,
                "User Logged In Successfully",
                result.Data);
            return Ok(response);

        }

        [HttpGet("getUser")]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> GetUser(){
            return Ok("Hello World");
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(string token)
        {
            var command = new UserRefreshTokenCommand(token);
            var result = await _commandResolver.ResolveHandler<UserRefreshTokenCommand, BaseResponse<UserRefreshTokenResponse>>(command);
            if(result.Data == null){
                return BadRequest(result);
            }
            BaseResponse<UserRefreshTokenResponse> response = new BaseResponse<UserRefreshTokenResponse>(
                true,
                200,
                "Token Refreshed Successfully",
                result.Data);
            return Ok(response);
        }

    }
}