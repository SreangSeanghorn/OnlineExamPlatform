using MassTransit;
using NotificationService.Domain.Events;
using NotificationService.Domain.Interfaces;
using NotificationService.Domain.UserRegistered;

namespace NotificationService.Infrastructure.Consumers;

public class UserRegisteredConsumer : IConsumer<UserRegisteredEventData<Content>>
{
    private readonly INotificationHandler _notificationHandler;
    private readonly IEmailSender _emailHandler;
    
    public UserRegisteredConsumer(INotificationHandler notificationHandler, IEmailSender emailHandler)
    {
        _notificationHandler = notificationHandler;
        _emailHandler = emailHandler;
    }
    public async Task Consume(ConsumeContext<UserRegisteredEventData<Content>> context)
    {
        var message = context.Message;
        var rawMessage = context.ReceiveContext.GetBody();
        var email = message.Content.Email;
        Console.WriteLine($"Received UserRegistered Emailk at {message.Content.Email}");
        Console.WriteLine($"Raw Kafka Message: {System.Text.Encoding.UTF8.GetString(rawMessage)}");

        Console.WriteLine($"Parsed Message: {message.EntityId}, {message.Content.UserName}, {message.Content.Email}, {message.Content.RoleId}");
        
        //send notification
      //  await _notificationHandler.UserRegistered(rawMessage);
        
        //send email
        await _emailHandler.SendEmailAsync(message.Content.Email, "User Registered", "You have successfully registered");
        Console.WriteLine("Email sent successfully");
        await Task.CompletedTask;
    }
}