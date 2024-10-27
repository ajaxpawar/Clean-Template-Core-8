using Domain.User;
using Infrastructure.Common.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHttpContextAccessor()
                .AddServices()
                //.AddBackgroundServices(configuration)
                .AddApplicationAuthorization()
                .AddApplicationAuthentication(configuration)
                .AddPersistence(configuration);

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Add Service

            return services;
        }
        private static IServiceCollection AddApplicationAuthorization(this IServiceCollection services)
        {
            //Add Application Authorization Services

            return services;
        }
        private static IServiceCollection AddApplicationAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Application Authentication Services
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration _configuration)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            @*#if(ServerType=="sql")
            services.AddDbContext<ApplicationDbContext>(options =>
           {
               //register sql server
               options.UseSqlServer(connectionString, sqlOptions =>
               {
                   sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
               });
           });
            #endif*@


            @*#if(ServerType=="mysql")

       services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, serverVersion,
                mySqlOptions => Assembly.GetExecutingAssembly()));

            #endif*@



            // Configure Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Identity options configuration
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            return services;
        }

    }

}
