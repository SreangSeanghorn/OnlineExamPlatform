using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Domain.Core.Event
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
        Guid EntityId { get; }
    }
}