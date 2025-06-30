using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Notifications
{
    public class NotificationDto : IMapWith<Notification>
    {
        public Guid Id { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string Type { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
