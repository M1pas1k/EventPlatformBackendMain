using Quartz;

namespace WebApplication.Infrastructure.BackgroundJobs
{
    public class AwaitSendEmail : IJob
    {
        public static readonly JobKey Key = new JobKey("await-send-email", "email");

        public async Task Execute(IJobExecutionContext context)
        {
            var eventId = context.MergedJobDataMap.GetString("eventId");
            var userId = context.MergedJobDataMap.GetString("userId");

            var jobDetail = JobBuilder.Create<SendEmail>()
                .WithIdentity(SendEmail.Key)
                .UsingJobData("email", "test@test.com")
                .UsingJobData("subject", "Event soon!")
                .UsingJobData("content", $"Event: {eventId}")
                .Build();

            var scheduler = context.Scheduler;
            var trigger = TriggerBuilder.Create()
                .StartNow()
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
