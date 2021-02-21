using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Interfaces.Slack;
using MetWorkingUserInfrastructure.Clients;
using Microsoft.EntityFrameworkCore;
using MetWorkingUserInfrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserInfrastructure
{
    using MassTransit;
    // using MetWorkingUserApplication.User.Consumer;

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
            // services.AddMassTransit(config =>
            // {
            //     config.AddConsumer<UserAddBoostConsumer>();
            //     config.UsingRabbitMq((ctx, cfg) =>
            //     {
            //         cfg.Host("amqp://guest:guest@localhost:5672");
            //         cfg.ReceiveEndpoint("user-boost-queue", c =>
            //         {
            //             c.ConfigureConsumer<UserAddBoostConsumer>(ctx);
            //         });
            //     });
            // });
            // services.AddMassTransitHostedService();
        }
    }
}