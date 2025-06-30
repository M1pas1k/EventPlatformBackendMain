using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.DTOs.Notifications
{
    public class NotificationCreateDto : IMapWith<Notification>
    {
        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public Guid UserId { get; set; }
    }
}
