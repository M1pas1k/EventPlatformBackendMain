using MediatR;
using WebApplication.Application.Features.Notifications.Commands;
using WebApplication.Infrastructure.Notifications;

namespace WebApplication.Application.Features.Notifications.Handlers
{
    public class SendNotificationHandler(INotificationService notificationService) : IRequestHandler<SendNotificationCommand, Unit>
    {
        public async Task<Unit> Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            await notificationService.SendNotificationAsync(request.Notification);
            return Unit.Value;
        }
    }

}
