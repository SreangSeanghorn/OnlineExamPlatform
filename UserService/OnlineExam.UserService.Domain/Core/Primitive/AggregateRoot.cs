using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Event;


namespace OnlineExam.UserService.Domain.Core.Primitive
{
    public class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> Events => _events;

        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
            Console.WriteLine("Event Raised"+domainEvent);
        }
        public void ClearEvents()
        {
            _events.Clear();
        }

        public List<IDomainEvent> GetDomainEvents()
        {
            return _events;
        }

        
    }
}