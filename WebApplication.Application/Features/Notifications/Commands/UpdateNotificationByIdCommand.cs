using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Notifications.Commands
{
    public class UpdateNotificationByIdCommand : IRequest<Result<NotificationDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public NotificationUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
