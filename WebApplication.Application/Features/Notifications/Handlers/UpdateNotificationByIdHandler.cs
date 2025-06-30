using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Features.Notifications.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class UpdateNotificationByIdHandler(IActions actions) : IRequestHandler<UpdateNotificationByIdCommand
        , Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(UpdateNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Notification, NotificationDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
