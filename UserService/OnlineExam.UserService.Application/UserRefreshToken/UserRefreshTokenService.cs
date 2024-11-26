using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using OnlineExam.UserService.Domain.RefreshTokens;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Authentication;

namespace OnlineExam.UserService.Application.UserRefreshToken
{
    public class UserRefreshTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserRefreshTokenService(IUserRepository userRepository
        , IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
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
            return new UserRefreshTokenResponse(
                _jwtTokenGenerator.GenerateToken(user.UserName,roles),
                newRefreshToken.Token
            )
            {     
            };

        }
        
    }
}