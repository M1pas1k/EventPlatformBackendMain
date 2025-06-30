using Microsoft.EntityFrameworkCore;
using Quartz;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Infrastructure.BackgroundJobs.Events
{
    public class ChangeEventStatus(IDatabaseContext db) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var eventId = context.MergedJobDataMap.GetString("eventId");
            var status = context.MergedJobDataMap.GetString("status");

            await db.Events
                .Where(e => e.Id == Guid.Parse(eventId))
                .ExecuteUpdateAsync(p => p
                    .SetProperty(e => e.Status, Enum.Parse<EventStatus>(status))
                );
        }
    }
}
