using MediatR;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Notifications.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class GetNotificationsHandler(IActions actions) : IRequestHandler<GetNotificationsQuery, ICollection<NotificationDto>>
    {
        public async Task<ICollection<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Notification, NotificationDto>(cancellationToken);
        }
    }
}
