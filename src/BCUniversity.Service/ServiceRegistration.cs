using BCUniversity.Domain.StudentAggregate;
using BCUniversity.Domain.SubjectAggregate;
using BCUniversity.Domain.TheatreAggregate;
using BCUniversity.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Service
{
    public static class ServiceRegistration
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddTransient<IStudentService, StudentService>();
        }
    }
}