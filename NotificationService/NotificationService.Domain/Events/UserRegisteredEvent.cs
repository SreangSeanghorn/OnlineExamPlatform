using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Domain.Events
{
    public class UserRegisteredEvent
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        
    }
}