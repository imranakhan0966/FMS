using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ozone.Application.Behaviours;
using Ozone.Application.Helpers;
//using Ozone.Application.Interfaces;
//using Ozone.Domain.Entities;
using System.Reflection;
using System;
using Ozone.Application.Interfaces;

namespace Ozone.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddScoped<IDataShapeHelper<Position>, DataShapeHelper<Position>>();
            //services.AddScoped<IDataShapeHelper<Employee>, DataShapeHelper<Employee>>();
            services.AddScoped<IModelHelper, ModelHelper>();
            services.AddScoped<IUserSessionHelper, UserSessionHelper>();
           // services.AddScoped<IMockData, MockData>();
        }
    }
}
