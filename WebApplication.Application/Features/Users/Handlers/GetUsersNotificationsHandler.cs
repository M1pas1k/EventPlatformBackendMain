using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUsersNotificationsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersNotificationsQuery, ICollection<UserNotificationDto>>
    {
        public async Task<ICollection<UserNotificationDto>> Handle(GetUsersNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await context.Notifications
                .AsNoTracking()
                .Where(ut => ut.UserId == request.UserId)
                .ProjectTo<UserNotificationDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
