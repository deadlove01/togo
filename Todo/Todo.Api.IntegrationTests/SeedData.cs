using System;
using Todo.Domains.Entities;
using Todo.Infras;

namespace Todo.Api.IntegrationTests
{

    public static class SeedData
    {
        public static void PopulateTestData(TodoContext dbContext)
        {
            var user1 = new User
            {
                Username = "firstUser",
                FirstName = "First",
                LastName = "Lee",
                Id = Guid.Parse("44f66382-ccfd-405e-bd85-0fab9c0036d5"),
                Membership = Membership.Basic
            };
            var user2 = new User
            {
                Username = "ravi113",
                FirstName = "Ravi",
                LastName = "Le",
                Id = Guid.Parse("55f66382-ccfd-405e-bd85-0fab9c003633"),
                Membership = Membership.Premium
            };
           dbContext.Users.Add(user1);
           dbContext.Users.Add(user2);

           dbContext.Tasks.Add(new Task
           {
               Content = "dummy task 1",
               Id = Guid.NewGuid(),
               Status = TaskStatus.Active,
               CreatedDate = DateTimeOffset.Now,
               UserId = user1.Id
           });
           dbContext.Tasks.Add(new Task
           {
               Content = "dummy task 2",
               Id = Guid.NewGuid(),
               Status = TaskStatus.Inactive,
               CreatedDate = DateTimeOffset.Now,
               UserId = user1.Id
           });
           dbContext.Tasks.Add(new Task
           {
               Content = "dummy task 3",
               Id = Guid.NewGuid(),
               Status = TaskStatus.Completed,
               CreatedDate = DateTimeOffset.Now,
               UserId = user2.Id
           });
            dbContext.SaveChanges();
        }
    }
}