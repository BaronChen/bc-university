using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Infrastructure.Common;
using BCUniversity.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Infrastructure
{
     public static class ServiceRegistrations
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddScoped<UniversityContext>();

            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ITheatreRepository, TheatreRepository>();
        }
    }
}