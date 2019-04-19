using BCUniversity.Domain.Common;

namespace BCUniversity.Service.Common
{
    public interface IRepository<T> where T : AggregateRoot
    {
        T Save(T aggregate);
        T GetById(string id);
    }
}