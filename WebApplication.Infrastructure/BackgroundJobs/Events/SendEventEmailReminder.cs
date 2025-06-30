using Quartz;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructure.BackgroundJobs.Events
{
    public class SendEventEmailReminder(IEmailSender emailSender, IActions actions) : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {
            var email = context.MergedJobDataMap.GetString("email");
            var eventId = context.MergedJobDataMap.GetString("eventId");
            var eventResult = await actions.GetById<Event>(Guid.Parse(eventId));
            if (eventResult.IsFailure) return;
            var event_ = eventResult.Value;

            await emailSender.SendAsync(email, "Event reminder", $"Hey! Don't miss this event: {event_.Title}. It starts at {event_.StartAt}", default);
        }
    }
}
