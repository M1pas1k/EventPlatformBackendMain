using Microsoft.AspNetCore.SignalR;
using WebApplication.Application.DTOs.Notifications;
using WebApplication.Application.Interfaces;
using WebApplication.Infrastructure.Interfaces;

namespace WebApplication.Infrastructure.Notifications
{
    public class NotificationService(IHubContext<NotificationHub> hubContext, IConnectionTracker tracker, IDatabaseContext dbContext) : INotificationService
    {

        public async Task SendNotificationAsync(NotificationDto notification)
        {
            var userIdString = notification.UserId.ToString();
            if (await tracker.IsUserConnected(userIdString))
            {
                await hubContext.Clients.Group(userIdString).SendAsync("ReceiveNotification", notification);
            }
        }
    }
}
