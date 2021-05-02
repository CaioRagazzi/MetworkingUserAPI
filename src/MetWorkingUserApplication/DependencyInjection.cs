using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using MediatR;
using MetWorkingUserApplication.Common.PipelineBehaviors;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.User.Handlers;
using MetWorkingUserApplication.User.Queries;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

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
        }  
    }   
}