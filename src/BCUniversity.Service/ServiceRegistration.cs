using BCUniversity.Service.Students;
using BCUniversity.Service.Subjects;
using BCUniversity.Service.Theatres;
using Microsoft.Extensions.DependencyInjection;

namespace BCUniversity.Service
{
    public static class ServiceRegistration
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITheatreService, TheatreService>();
            services.AddTransient<ISubjectService, SubjectService>();
        }
    }
}