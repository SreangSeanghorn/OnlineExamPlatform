namespace OnlineExam.UserService.Infrastructure.Authentication.JwtTokenGenerators
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username,List<string> roles,List<string> permissions);
    }
}