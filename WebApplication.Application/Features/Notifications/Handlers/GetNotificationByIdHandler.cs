using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Notifications.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class GetNotificationByIdHandler(IActions actions) : IRequestHandler<GetNotificationByIdQuery, Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Notification, NotificationDto>(request.Id, cancellationToken);
        }
    }
}
