using BCUniversity.Domain.Common;
using BCUniversity.Service.Common;
using Microsoft.EntityFrameworkCore;

namespace BCUniversity.Infrastructure.Common
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly DbContext _dbContext;
        
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public T Save(T aggregate)
        {
            _dbContext.Set<T>().Update(aggregate);

            return aggregate;
        }

        public T GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}