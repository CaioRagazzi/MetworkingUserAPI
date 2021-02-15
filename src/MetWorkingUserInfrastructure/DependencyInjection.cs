using MetWorkingUserApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using MetWorkingUserInfrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserInfrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("MetWorkingUser"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseMySql(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

                services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            }
        }
    }
}