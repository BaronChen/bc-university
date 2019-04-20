using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCUniversity.Domain.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task<string> Save(T aggregate);
        Task<T> GetById(string id);

        Task<IEnumerable<T>> ListAll();
    }
}