using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace OnlineExam.UserService.Infrastructure.Authentication.JwtTokenGenerators
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }
    public string GenerateToken(string username, List<string> roles, List<string> permissions)
    {
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(roles.Select(role => new Claim(ClaimTypes.Role, role)))
            .Union(new[]
            {
                new Claim("permissions", string.Join(" ", permissions))
            });
        var signingKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
        , SecurityAlgorithms.HmacSha256);
        Console.WriteLine(_jwtSettings.Secret);
        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            signingCredentials:  signingKey
        );
           
        Console.WriteLine("Token: " + new JwtSecurityTokenHandler().WriteToken(token));
        return new JwtSecurityTokenHandler().WriteToken(token);
    } 
    
    }

}