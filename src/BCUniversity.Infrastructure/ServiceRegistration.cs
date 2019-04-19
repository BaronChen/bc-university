using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Infrastructure
{
     public static class ServiceRegistrations
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ISubjectRepository, SubjectRepository>();
        }
    }
}