using MetWorkingUserAPI.Interfaces;
using MetWorkingUserAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserAPI.Configuration
{
    public static class DiStartupExtensions
    {
        public static void ConfigureDiServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }  
    }   
}