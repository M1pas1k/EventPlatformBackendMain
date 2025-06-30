using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Interfaces;

namespace WebApplication.Infrastructure.Payments
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPayments(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPaymentsProvider, MockPaymentsProvider>();
            return services;
        }
    }
}
