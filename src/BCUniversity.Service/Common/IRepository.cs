using System.Threading.Tasks;
using BCUniversity.Domain.Common;

namespace BCUniversity.Service.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        Task Save(T aggregate);
        Task<T> GetById(string id);
    }
}