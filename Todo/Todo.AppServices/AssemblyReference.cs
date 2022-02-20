using Microsoft.Extensions.DependencyInjection;
using Todo.AppServices.Services;
using Todo.AppServices.Services.Concrete;
using Todo.Domains.Repository;
using Todo.Infras.Repository;

namespace Todo.AppServices
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }

}