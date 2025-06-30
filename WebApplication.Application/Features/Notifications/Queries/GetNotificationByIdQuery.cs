using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Notifications.Queries
{
    public class GetNotificationByIdQuery : IRequest<Result<NotificationDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"notification:{Id}";
    }
}
