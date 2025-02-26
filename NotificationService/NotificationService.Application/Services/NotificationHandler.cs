using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationService.Domain.Interfaces;
using NotificationService.Domain.UserRegistered;

namespace NotificationService.Application.Services
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly IEmailSender _emailSender;

        public NotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public Task UserRegistered(UserRegisteredEventData<Content> eventData)
        {
            var subject = "Welcome to the Online Examination Service";
            var message = $"Dear {eventData.Content.UserName},\n\n" +
                          "Welcome to the Our Online Examination Service. We are excited to have you on board.\n\n" +
                          "Best Regards,\n" +
                          "Online Examination Service Team";
            return _emailSender.SendEmailAsync("seanghornsreang92@gmail.com", subject, message);


        }
    }
}