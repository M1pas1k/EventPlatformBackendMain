using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUsersNotificationsQuery : IRequest<ICollection<UserNotificationDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:notifications";
    }
}
