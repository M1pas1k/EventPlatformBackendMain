using Microsoft.Extensions.Logging;
using Quartz;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;
using WebApplication.Infrastructure.BackgroundJobs.Events;

namespace WebApplication.Infrastructure.BackgroundJobs
{
    public class QuartzJobScheduler(ISchedulerFactory schedulerFactory, ILogger<QuartzJobScheduler> logger) : IJobScheduler
    {
        private readonly ISchedulerFactory _schedulerFactory = schedulerFactory;
        public async Task ScheduleEventEmailReminder(DateTimeOffset executeAt, string email, Guid eventId, CancellationToken cancellationToken)
        {
            var jobDetail = JobBuilder.Create<SendEventEmailReminder>()
              .WithIdentity($"email-reminder:{email}:event:{eventId}")
              .UsingJobData("email", email)
              .UsingJobData("eventId", eventId.ToString())
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task ScheduleChangeEventStatus(DateTimeOffset executeAt, EventStatus status, Guid eventId, CancellationToken cancellationToken)
        {
            var jobDetail = JobBuilder.Create<ChangeEventStatus>()
              .WithIdentity($"change-event-status:{eventId}")
              .UsingJobData("eventId", eventId.ToString())
              .UsingJobData("status", status.ToString())
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();
        }

        public async Task ScheduleEmailSend(DateTimeOffset executeAt, string email, string subject, string content, CancellationToken cancellationToken)
        {
            var jobDetail = JobBuilder.Create<SendEmail>()
              .WithIdentity(SendEmail.Key)
              .UsingJobData("email", email)
              .UsingJobData("subject", subject)
              .UsingJobData("content", content)
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task ScheduleAwait(DateTimeOffset executeAt, Guid userId, Guid eventId, CancellationToken cancellationToken = default)
        {
            var jobDetail = JobBuilder.Create<AwaitSendEmail>()
              .WithIdentity(AwaitSendEmail.Key)
              .UsingJobData("userId", userId.ToString())
              .UsingJobData("eventId", eventId.ToString())
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task DeleteJob(string key, string group)
        {
            var scheduler = await _schedulerFactory.GetScheduler();
            await scheduler.DeleteJob(new JobKey(key, group));
        }
    }
}
