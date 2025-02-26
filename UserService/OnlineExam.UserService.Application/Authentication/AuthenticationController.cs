using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineExam.UserService.Application.GoogleLogins;
using OnlineExam.UserService.Application.Shared.Resolver;
using OnlineExam.UserService.Application.Shared.Responses;
using OnlineExam.UserService.Application.UserLogin;
using OnlineExam.UserService.Application.UserRefreshToken;
using OnlineExam.UserService.Application.UserRegistered;
using OnlineExam.UserService.Infrastructure.Authentication;

namespace OnlineExam.UserService.Application.Authentication
{
    [ApiController]
    [Route("api/user")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICommandResolver _commandResolver;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ICommandResolver commandResolver, IConfiguration configuration)
        {
            _commandResolver = commandResolver;
            _configuration = configuration;
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
        [HttpGet("login/google")]
        public IActionResult GoogleLogin()
        {
            var OAuthSetting = _configuration.GetSection("Auth0Settings").Get<Auth0Settings>();
            var domain = OAuthSetting.Domain;
            var clientId = OAuthSetting.ClientId;
            var callbackUrl = OAuthSetting.CallbackUrl;
            var Audience = OAuthSetting.Audience;
            var scope = "openid read:user profile email";
            var loginUrl = $"https://{domain}/authorize?response_type=code&client_id={clientId}&redirect_uri={callbackUrl}&scope={scope}&audience={Audience}";
            return Redirect(loginUrl);
        }
        
        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code)
        {
            if(string.IsNullOrEmpty(code)){
                return BadRequest();
            }
            var OAuthSetting = _configuration.GetSection("Auth0Settings").Get<Auth0Settings>();
            var domain = OAuthSetting.Domain;
            var clientId = OAuthSetting.ClientId;
            var clientSecret = OAuthSetting.ClientSecret;
            var callbackUrl = OAuthSetting.CallbackUrl;
            
            var tokenRequestBody = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string?, string?>("grant_type", "authorization_code"),
                    new KeyValuePair<string?, string?>("client_id", clientId),
                    new KeyValuePair<string?, string?>("client_secret", clientSecret),
                    new KeyValuePair<string?, string?>("code", code),
                    new KeyValuePair<string?, string?>("redirect_uri", callbackUrl)
                }
            );
            var httpClient = new HttpClient();
            var tokenResponse = await httpClient.PostAsync($"https://{domain}/oauth/token", tokenRequestBody);
            
            if(!tokenResponse.IsSuccessStatusCode){
                return BadRequest("Failed to get token");
            }
            var tokenResponseData = await tokenResponse.Content.ReadAsStringAsync();
            var tokens = JsonSerializer.Deserialize<GoogleTokenResponse>(tokenResponseData);
            
            return Ok(tokens);
            
        }
        
        [HttpGet("userInformation")]
        public async Task<IActionResult> UserInformation(string idToken)
        {
            if(string.IsNullOrEmpty(idToken)){
                return BadRequest();
            }
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(idToken);

            var email = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            var name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value;

            return Ok(new { Email = email, Name = name });
        }
        [HttpGet("protected")]
        [Authorize(Policy = "ReadUser")]
        public IActionResult Get()
        {
            return Ok("You have accessed a protected resource!");
        }

    }
}