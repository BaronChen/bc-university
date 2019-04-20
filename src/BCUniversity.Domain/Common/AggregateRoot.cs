using System.Collections.Generic;
using System.Linq;
using BCUniversity.Domain.Common.Events;

namespace BCUniversity.Domain.Common
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<DomainEvent> _domainEvents;
        
        protected AggregateRoot(string id) : base(id)
        {
            _domainEvents = new List<DomainEvent>();
        }

        protected void RaiseDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public IEnumerable<DomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }
        
    }
}