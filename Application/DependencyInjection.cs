﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(options =>

                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            return services;
        }
    }
}
