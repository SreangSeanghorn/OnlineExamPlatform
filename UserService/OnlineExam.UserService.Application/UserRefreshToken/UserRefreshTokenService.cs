using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using OnlineExam.UserService.Domain.RefreshTokens;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Authentication.JwtTokenGenerators;

namespace OnlineExam.UserService.Application.UserRefreshToken
{
    public class UserRefreshTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IRoleRepository _roleRepository;

        // public UserRefreshTokenService(IUserRepository userRepository
        // , IJwtTokenGenerator jwtTokenGenerator)
        // {
        //     _userRepository = userRepository;
        //     _jwtTokenGenerator = jwtTokenGenerator;
        // }

        public UserRefreshTokenService(IUserRepository userRepository
            , IJwtTokenGenerator jwtTokenGenerator
            , IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleRepository = roleRepository;
        }
        public async Task<UserRefreshTokenResponse> RefreshToken(string refreshToken)
        {
            var user = await _userRepository.GetUserByRefreshToken(refreshToken);
            if (user == null)
            {
                throw new Exception("Invalid token.");
            }
            
            var newRefreshToken = new RefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow.AddDays(7));
            user.AddRefreshToken(newRefreshToken,DateTime.UtcNow.AddDays(7));

            await _userRepository.SaveChangesAsync();
            var roles = user.Roles.Select(r => r.Name).ToList();
            var permissions = user.Roles.SelectMany(r => r.RolePermissions).Select(rp => rp.Permission.Name).ToList();
            return new UserRefreshTokenResponse(
              //  _jwtTokenGenerator.GenerateToken(user.UserName,roles),
                _jwtTokenGenerator.GenerateToken(user.UserName, roles,permissions),
                newRefreshToken.Token
            )
            {     
            };

        }
        
    }
}