using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Domain.Common.Events
{
     public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private IEnumerable<DomainEventProcessor> GenerateWrappedHandlers(DomainEvent domainEvent)
        {
            var handlerType = typeof(IHandler<>).MakeGenericType(domainEvent.GetType());
            var wrapperType = typeof(DomainEventProcessor<>).MakeGenericType(domainEvent.GetType());
            var handlers = _serviceProvider.GetServices(handlerType);
            return handlers.Select(handler => (DomainEventProcessor) Activator.CreateInstance(wrapperType, handler));
        }

        public async Task Dispatch(DomainEvent domainEvent)
        {
            foreach (var handler in GenerateWrappedHandlers(domainEvent))
            {
                await handler.Handle(domainEvent);
            }
        }

        private abstract class DomainEventProcessor
        {
            public abstract Task Handle(DomainEvent domainEvent);
        }

        private class DomainEventProcessor<T> : DomainEventProcessor
            where T : DomainEvent
        {
            private readonly IHandler<T> _handler;

            public DomainEventProcessor(IHandler<T> handler)
            {
                _handler = handler;
            }

            public override async Task Handle(DomainEvent domainEvent)
            {
                await _handler.Handle(domainEvent as T);
            }
        }
    }
}