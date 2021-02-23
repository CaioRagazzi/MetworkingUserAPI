using System;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Interfaces.Broker;
using MetWorkingUserApplication.Interfaces.Slack;
using MetWorkingUserInfrastructure.Broker;
using MetWorkingUserInfrastructure.Clients;
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

            services.AddTransient<ISlackClient>(c => new SlackClient(configuration));
            services.AddSingleton<IBroker>(new RabbitMqBroker());
        }
    }
}