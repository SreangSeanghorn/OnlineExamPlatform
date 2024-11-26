using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Domain.Core.Event
{
    public interface IEventBus
    {
        Task Publish<T>(T domainEvent) where T : IDomainEvent;
        void Subscribe<T, TH>()
            where T : IDomainEvent
            where TH : IDomainEventHandler<T>;
    }
}