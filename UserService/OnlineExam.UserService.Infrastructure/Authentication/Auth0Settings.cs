namespace OnlineExam.UserService.Infrastructure.Authentication;

public class Auth0Settings
{
    public string? Domain { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Audience { get; set; }
    public string? ResponseType { get; set; }
    public bool? SaveTokens { get; set; }
    public string? CallbackUrl { get; set; }
}