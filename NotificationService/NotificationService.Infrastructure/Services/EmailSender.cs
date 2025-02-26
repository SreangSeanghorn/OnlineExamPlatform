using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Azure.Communication.Email;
using Microsoft.Extensions.Options;
using MimeKit;
using NotificationService.Domain.Interfaces;
using NotificationService.Infrastructure.MailSettings;

namespace NotificationService.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            // Validate the email address
            if (string.IsNullOrWhiteSpace(toEmail) || !IsValidEmail(toEmail))
            {
                Console.WriteLine("Invalid email address: " + toEmail);
                throw new FormatException($"Invalid email address: {toEmail}");
            }

            using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);

                if (_smtpSettings.EnableSsl)
                {
                    client.EnableSsl = false;
                }

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.Host),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);
                Console.WriteLine("Sending email to: " + toEmail);
                await client.SendMailAsync(mailMessage);
                Console.WriteLine("Email sent successfully");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid email address format: " + email);
                return false;
            }
        }
    }



}