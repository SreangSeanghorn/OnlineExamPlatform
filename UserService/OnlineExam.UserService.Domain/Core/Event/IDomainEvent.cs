using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExam.UserService.Domain.Core.Event
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        Guid EntityId { get; }
    }
}