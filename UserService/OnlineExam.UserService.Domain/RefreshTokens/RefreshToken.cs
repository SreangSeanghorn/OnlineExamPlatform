using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Primitive;

namespace OnlineExam.UserService.Domain.RefreshTokens
{
    public class RefreshToken : Entity<Guid>
    {
        public string Token { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public bool IsRevoked { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;

        public RefreshToken(string token, DateTime expiryDate)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
            ExpiryDate = expiryDate;
            IsRevoked = false;
        }

        public void Revoke()
        {
            if (IsRevoked) throw new InvalidOperationException("Token is already revoked.");
            IsRevoked = true;
        }

        public bool IsValid()
        {
            return !IsRevoked && !IsExpired;
        }
    }

}