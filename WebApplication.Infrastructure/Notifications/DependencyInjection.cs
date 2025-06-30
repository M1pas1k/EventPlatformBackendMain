using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Infrastructure.Interfaces;

namespace WebApplication.Infrastructure.Notifications
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddNotificationHub(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IConnectionTracker, ConnectionTracker>();

            return services;
        }
    }
}
