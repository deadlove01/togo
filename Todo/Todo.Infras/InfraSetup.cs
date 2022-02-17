using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infras
{
    public static class InfraSetup
    {
        public static IServiceCollection AddInfras(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TodoContext>(c => c.UseSqlite(connectionString));
            return services;
        }
    }
}