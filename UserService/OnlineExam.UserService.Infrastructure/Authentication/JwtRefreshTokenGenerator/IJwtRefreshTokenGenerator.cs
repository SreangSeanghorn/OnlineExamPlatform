using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Infrastructure.Authentication.JwtRefreshTokenGenerator
{
    public interface IJwtRefreshTokenGenerator
    {
        public string GenerateRefreshToken();
        public DateTime GetExpiryDate();
    }
}