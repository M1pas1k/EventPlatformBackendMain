using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Notifications.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class CreateNotificationHandler(IActions actions) : IRequestHandler<CreateNotificationCommand, Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Notification, NotificationDto>(request.Entity, cancellationToken);
        }
    }
}
