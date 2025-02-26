using Microsoft.AspNetCore.SignalR;

namespace NotificationService.Infrastructure.Notification;

public class NotificationHub : Hub
{
    public async Task NotifyUser(string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}