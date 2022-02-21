using System;
using Todo.Domains.Entities;
using Todo.Infras;

namespace Todo.Api.IntegrationTests
{

    public static class SeedData
    {
        public static void PopulateTestData(TodoContext dbContext)
        {
           dbContext.Users.Add(new User
           {
               Username = "firstUser",
               FirstName = "First",
               LastName = "Lee",
               Id = Guid.NewGuid()
           });
           dbContext.Users.Add(new User
           {
               Username = "ravi113",
               FirstName = "Ravi",
               LastName = "Le",
               Id = Guid.NewGuid()
           });
            dbContext.SaveChanges();
        }
    }
}