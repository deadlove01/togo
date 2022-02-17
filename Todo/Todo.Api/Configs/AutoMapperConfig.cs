using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Api.Configs
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            var asms = new List<Assembly>()
            {
                typeof(Todo.AppServices.AssemblyReference).Assembly
            };
            services.AddAutoMapper(asms);
            return services;
        }
    }
}