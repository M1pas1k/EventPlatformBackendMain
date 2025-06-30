using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class User : BaseEntity
    {

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime PasswordUpdatedAt { get; set; } = DateTime.UtcNow;


        public ICollection<Role> Roles { get; set; } = [];

        public ICollection<Event> Events { get; set; } = [];

        public ICollection<UserTicket> Tickets { get; set; } = [];

        public ICollection<Purchase> Purchases { get; set; } = [];

        public ICollection<Notification> Notifications { get; set; } = [];

        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
