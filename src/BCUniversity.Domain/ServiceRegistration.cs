using BCUniversity.Domain.Common.Events;
using BCUniversity.Domain.DomainService;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Domain
{
    public static class ServiceRegistration
    {
        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUniversityDomainService, UniversityDomainService>();
            services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}