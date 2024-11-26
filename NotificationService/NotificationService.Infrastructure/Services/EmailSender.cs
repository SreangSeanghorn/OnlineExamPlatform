using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message)
        {
            Console.WriteLine($"Sending email to {toEmail} with subject {subject} and message {message}");
            return Task.CompletedTask;
        }
    }
}