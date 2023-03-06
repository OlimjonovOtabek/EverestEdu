using EverestEduApplication.Abstractions;
using EverestEduApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EverestEduApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGroupService, GroupService>();

            return services;
        }

    }
}
