using WebApplication.Domain.Enums;

namespace WebApplication.Application.Interfaces
{
    public interface IJobScheduler
    {
        Task ScheduleChangeEventStatus(DateTimeOffset executeAt, EventStatus status, Guid eventId, CancellationToken cancellationToken);
        Task ScheduleEventEmailReminder(DateTimeOffset executeAt, string email, Guid eventId, CancellationToken cancellationToken);
    }
}
