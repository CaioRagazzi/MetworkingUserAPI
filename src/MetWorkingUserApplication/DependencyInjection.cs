using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using MetWorkingUserApplication.Common.PipelineBehaviors;
using MetWorkingUserApplication.Interfaces.Slack;
using MetWorkingUserApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MetWorkingUserApplication
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<ISlackService, SlackService>();
        }  
    }   
}