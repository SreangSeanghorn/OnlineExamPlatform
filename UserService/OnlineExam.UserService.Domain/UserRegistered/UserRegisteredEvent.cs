using System;
using OnlineExam.UserService.Domain.Core.Event;

namespace OnlineExam.UserService.Domain.UserRegistered

{
    public class UserRegisteredEvent : DomainEvent<UserRegisteredEventData>
    {
        public UserRegisteredEvent(Guid entityId, UserRegisteredEventData content) : base(entityId, content)
        {
        }
    }
}
