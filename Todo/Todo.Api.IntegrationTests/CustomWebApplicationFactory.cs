using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Todo.AppServices.Helpers;
using Todo.Infras;

namespace Todo.Api.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public IOptions<AppSettings> AppSettings;
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                var projectDir = Directory.GetCurrentDirectory();
                var configPath = Path.Combine(projectDir, "appsettings.test.json");

                config.AddJsonFile(configPath);
                config.AddEnvironmentVariables();
            });
            
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                services
                    .AddEntityFrameworkSqlite()
                    .BuildServiceProvider();
                var serviceProvider = services.BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<TodoContext>(options =>
                {
                    options.UseSqlite("DataSource=Todo_Test.dbo");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<TodoContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    appDb.Database.EnsureDeleted();
                    appDb.Database.EnsureCreated();
                    
                    AppSettings = scopedServices.GetRequiredService<IOptions<AppSettings>>();

                    try
                    {
                        // Seed the database with some specific test data.
                        SeedData.PopulateTestData(appDb);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}