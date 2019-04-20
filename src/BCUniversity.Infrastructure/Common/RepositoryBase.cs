using System.Collections.Generic;
using System.Threading.Tasks;
using BCUniversity.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Common
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : AggregateRoot
    {
        protected readonly UniversityContext _dbContext;
        
        protected RepositoryBase(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract Task Save(T aggregate);

        public abstract Task<T> GetById(string id);
        public abstract Task<IEnumerable<T>> ListAll();
    }
}