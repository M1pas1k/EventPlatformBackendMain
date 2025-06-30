using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Notifications.Commands
{
    public class CreateNotificationCommand : IRequest<Result<NotificationDto>>, ICacheInvalidate
    {
        public NotificationCreateDto? Entity { get; set; }

        public string[] CacheKeys => ["notifications*"];
    }
}
