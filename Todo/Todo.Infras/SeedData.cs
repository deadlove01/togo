using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo.Domains.Entities;

namespace Todo.Infras
{
    public class SeedData
    {
        public static void InitialData(TodoContext context, IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<SeedData>>();
            logger.LogInformation("Start seeding data...");
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                logger.LogError("Seed data was already created");
                return;
            }

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = "firstUser",
                Password = "example",
                Membership = Membership.Basic,
                FirstName = "Ravi",
                LastName = "Le"
            });

            context.SaveChanges();
            
            logger.LogInformation("Finish seeding data.");
        }
    }
}