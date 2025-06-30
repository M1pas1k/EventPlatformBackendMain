using MediatR;
using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Application.Features.Notifications.Commands
{
    public class SendNotificationCommand : IRequest
    {
        public Guid UserId { get; set; }

        public NotificationDto Notification { get; set; }
    }
}
