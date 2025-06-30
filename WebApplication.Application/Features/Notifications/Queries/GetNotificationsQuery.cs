using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Notifications.Queries
{
    public class GetNotificationsQuery : IRequest<ICollection<NotificationDto>>, ICacheable
    {
        public string CacheKey => $"notifications";
    }
}
