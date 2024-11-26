using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamManagement.Domain.Core.Event;



namespace ExamManagement.Domain.Core.Primitive
{
    public class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events => _events;

        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
        public void ClearEvents()
        {
            _events.Clear();
        }

        
    }
}