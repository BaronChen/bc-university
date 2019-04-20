using System.Threading.Tasks;

namespace BCUniversity.Domain.Common.Events
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(DomainEvent domainEvent);
    }
}