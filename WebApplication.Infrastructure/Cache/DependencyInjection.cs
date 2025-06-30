using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructure.Cache
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(configuration["Redis:Connection"]!);
            });

            services.AddScoped<ICache>(provider =>
            {
                return new RedisCacheProvider(provider.GetRequiredService<IConnectionMultiplexer>());
            });

            return services;
        }
    }
}
