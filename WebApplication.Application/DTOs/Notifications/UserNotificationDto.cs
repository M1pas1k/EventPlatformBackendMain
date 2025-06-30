using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.DTOs.Notifications
{
    public class UserNotificationDto : IMapWith<Notification>
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public NotificationType Type { get; set; }
    }
}
