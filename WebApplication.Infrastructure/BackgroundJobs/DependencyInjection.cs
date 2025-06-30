using WebApplication.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.AspNetCore;

namespace WebApplication.Infrastructure.BackgroundJobs
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBackgroundScheduler(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Database:Connection"]
                ?? throw new ArgumentNullException(nameof(configuration), "Database connection is missing in configuration.");

            services.AddQuartz(q =>
            {
                q.UsePersistentStore(persistance =>
                {
                    persistance.UseProperties = true;
                    persistance.UseSystemTextJsonSerializer();
                    persistance.UsePostgres(p =>
                    {
                        p.TablePrefix = "quartz.qrtz_";
                        p.ConnectionString = connectionString;
                    });
                });
            });


            services.AddQuartzServer(options =>
            {
                options.AwaitApplicationStarted = true;
                options.WaitForJobsToComplete = true;
            });

            services.AddSingleton<IJobScheduler, QuartzJobScheduler>();

            return services;
        }
    }
}
