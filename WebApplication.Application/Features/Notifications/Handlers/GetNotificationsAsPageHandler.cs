using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Notifications.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class GetNotificationsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetNotificationsAsPageQuery, Page<NotificationDto>>
    {
        public async Task<Page<NotificationDto>> Handle(GetNotificationsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Notifications.ProjectTo<NotificationDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
