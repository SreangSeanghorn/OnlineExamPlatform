using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineExam.UserService.Domain.RefreshTokens;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Authentication;
using OnlineExam.UserService.Infrastructure.Authentication.JwtRefreshTokenGenerator;

namespace OnlineExam.UserService.Application.UserLogin
{
    public class UserLoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtRefreshTokenGenerator _jwtRefreshTokenGenerator;

        public UserLoginService(IUserRepository userRepository
        , IPasswordHasher<User> passwordHasher
        , IJwtTokenGenerator jwtTokenGenerator
        , IRoleRepository roleRepository
        , IJwtRefreshTokenGenerator jwtRefreshTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleRepository = roleRepository;
            _jwtRefreshTokenGenerator = jwtRefreshTokenGenerator;
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<UserLoginResponse> LoginUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username) ?? throw new UserNotFoundException("User not foundsss");
            if (_passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
            {
                var roles = user.Roles.Select(r => r.Name).ToList();
                var token = _jwtTokenGenerator.GenerateToken(username, roles);
                var refreshToken = _jwtRefreshTokenGenerator.GenerateRefreshToken();
                var refreshTokenObj = new RefreshToken(
                    refreshToken,
                    _jwtRefreshTokenGenerator.GetExpiryDate()

                );
                user.AddRefreshToken(refreshTokenObj,DateTime.UtcNow.AddMinutes(30)); 
                await _userRepository.SaveChangesAsync();
                return new UserLoginResponse(token, refreshToken, DateTime.UtcNow.AddMinutes(30));
            }
            throw new InvalidCredentialException("Invalid credentials");

        }
    }

}