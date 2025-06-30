using WebApplication.Application.DTOs.Notifications;

namespace WebApplication.Infrastructure.Notifications
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationDto notification);
    }
}
