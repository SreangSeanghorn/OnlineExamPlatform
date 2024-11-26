using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Repositories;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Domain.RefreshTokens
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        public Task<RefreshToken> GetRefreshToken(string refreshToken);
        
    }
}