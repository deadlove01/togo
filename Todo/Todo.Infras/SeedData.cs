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

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = "firstUser",
                Password = "example",
                Membership = Membership.Basic,
                FirstName = "First",
                LastName = "Lee"
            };
            
            var user2 = new User
            {
                Id = Guid.NewGuid(),
                Username = "ravi113",
                Password = "123123",
                Membership = Membership.Standard,
                FirstName = "Ravi",
                LastName = "Le"
            };
            
            context.Users.Add(user);
            context.Users.Add(user2);

            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Task
                {
                    Id = Guid.NewGuid(),
                    Content = "This is seed task 1",
                    Status = TaskStatus.Active,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = user.Id
                });
                
                context.Tasks.Add(new Task
                {
                    Id = Guid.NewGuid(),
                    Content = "This is seed task 2",
                    Status = TaskStatus.Completed,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = user.Id
                });
                
                context.Tasks.Add(new Task
                {
                    Id = Guid.NewGuid(),
                    Content = "This is seed task 3",
                    Status = TaskStatus.Active,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = user2.Id
                });
                
                context.Tasks.Add(new Task
                {
                    Id = Guid.NewGuid(),
                    Content = $"This is seed task with random text {new Random().Next(9999999)}",
                    Status = TaskStatus.Active,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = user.Id
                });
            }

            context.SaveChanges();
            
            logger.LogInformation("Finish seeding data.");
        }
    }
}