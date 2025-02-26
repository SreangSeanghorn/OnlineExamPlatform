namespace OnlineExam.UserService.Infrastructure.Authentication;

public class OpenIdConnectSettings
{
    public string? Authority { get; set; }
    public string?  Audience { get; set; }
    public string?   ClientId { get; set; }
    public string?  ClientSecret { get; set; }
    public string ? ResponseType { get; set; }
    public bool?  SaveTokens { get; set; }
    
}