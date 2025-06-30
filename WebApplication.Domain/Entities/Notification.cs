using WebApplication.Domain.Common;
using WebApplication.Domain.Enums;

namespace WebApplication.Domain.Entities
{
    public class Notification : BaseEntity
    {

        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
