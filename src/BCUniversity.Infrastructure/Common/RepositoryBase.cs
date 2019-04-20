using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.Common;
using BCUniversity.Domain.Common.Events;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Common
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly UniversityContext _dbContext;

        protected readonly IDomainEventDispatcher _domainEventDispatcher;
        
        protected RepositoryBase(UniversityContext dbContext, IDomainEventDispatcher domainEventDispatcher)
        {
            _dbContext = dbContext;
            _domainEventDispatcher = domainEventDispatcher;
        }

        protected async Task DispatchEvents(T aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.GetDomainEvents())
            {
                await _domainEventDispatcher.Dispatch(domainEvent);
            }
        } 
        
        public abstract Task<string> Save(T aggregate);

        public abstract Task<T> GetById(string id);
        public abstract Task<IEnumerable<T>> ListAll();
    }
}