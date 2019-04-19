using BCUniversity.Infrastructure.Subject;
using BCUniversity.Service.Subject;
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