using WebApplication.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Infrastructure.RandomCodeGeneration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCodeGeneration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRandomCodeGeneration, RandomCodeGeneration>();
            return services;
        }
    }
}
