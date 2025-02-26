using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationService.Domain.UserRegistered;

namespace NotificationService.Domain.Interfaces
{
    public interface INotificationHandler
    {
        Task UserRegistered( UserRegisteredEventData<Content> eventData);
    }
}