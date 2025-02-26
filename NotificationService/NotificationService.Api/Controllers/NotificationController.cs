using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Services;
using NotificationService.Domain.Events;
using NotificationService.Domain.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationHandler _notificationHandler;

    public NotificationController(INotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;
    }

 
}