using System;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MetWorkingUserInfrastructure.Persistence;
using MetWorkingUserInfrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace MetWorkingUserInfrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration["ConnectionStrings:DefaultConnection"],
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.EnableRetryOnFailure();
                    }), ServiceLifetime.Transient);

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IGeoService, GeoService>();
            
            services.AddHttpClient<IGeoService, GeoService>(client =>
                {
                    client.BaseAddress = new Uri(configuration["geoServiceBaseURL"]);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(message => HttpPolicyExtensions.HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));
        }
    }
}