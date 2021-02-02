using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserApplication
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }  
    }   
}