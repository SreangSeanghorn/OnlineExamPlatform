using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Domain.Core.Event
{
    public interface IEventPublisher
    {
        Task Publish<T>(T @event) where T : IDomainEvent;
    }
}