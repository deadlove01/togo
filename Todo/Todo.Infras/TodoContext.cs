using Microsoft.EntityFrameworkCore;
using Todo.Domains.Entities;

namespace Todo.Infras
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

    }
}