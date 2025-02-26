
namespace NotificationService.Domain.Events
{
    public class UserRegisteredEvent
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        
    }
}