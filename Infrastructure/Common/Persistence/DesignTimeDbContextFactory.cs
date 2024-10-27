using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Common.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        // Method to create DbContext during design-time for migrations or scaffolding

        public ApplicationDbContext CreateDbContext(string[] args)
        {

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api"))
                .AddJsonFile("appsettings.json")
            .Build();

            // Retrieve the connection string named 'DefaultConnection' from the configuration
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // Create a DbContextOptionsBuilder to configure the DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Determine the database provider dynamically based on the connection string
            @*#if(ServerType=="sql")
            //this is sql
            optionsBuilder.UseSqlServer(connectionString);

            #endif*@

            @*#if(ServerType=="mysql")
            //this is mysql
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            #endif*@



            // Return a new instance of ApplicationDbContext with the configured options
            return new ApplicationDbContext(optionsBuilder.Options);
        }

    }
}
