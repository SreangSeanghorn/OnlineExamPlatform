namespace NotificationService.Domain.UserRegistered;

public class Content
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public Guid RoleId { get; set; }
}