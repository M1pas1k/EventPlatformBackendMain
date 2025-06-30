using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Notifications.Queries
{
    public class GetNotificationsAsPageQuery : IRequest<Page<NotificationDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"notifications:page:{Page.Index},{Page.Size}";
    }
}
