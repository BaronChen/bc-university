using System.Threading.Tasks;

namespace BCUniversity.Domain.Common.Events
{
    public interface IHandler<in T> where T : DomainEvent
    {
        Task Handle(T domainEvent);
    }
}