using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.DTOs.Notifications
{
    public class NotificationUpdateDto : IMapWith<Notification>
    {
        public string? Subject { get; set; }

        public string? Content { get; set; }

        public NotificationType? Type { get; set; }
    }
}
