using System;
using MassTransit;
using OnlineExam.Domain.Entities.Users;
using OnlineExam.UserService.Domain.UserRegistered;

namespace OnlineExam.UserService.Application.UserRegistered;

public class UserRegisteredEventConsumer : IConsumer<UserRegisteredEvent>
{
    public Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var @event = context.Message;
        Console.WriteLine($"User Registered Event: {@event.EntityId},Email: {@event.Content.Email}, Name: {@event.Content.UserName}");
        return Task.CompletedTask;
    }
}
