using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Domain.Interfaces
{
    public interface INotificationHandler
    {
        Task UserRegistered(string userName, string email);
    }
}