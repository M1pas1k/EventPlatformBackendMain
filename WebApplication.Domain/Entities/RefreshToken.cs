using System.Text.Json.Serialization;
using WebApplication.Domain.Common;

namespace WebApplication.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {

        public string Token { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        [JsonIgnore]
        public bool IsActive { get => RevokedAt == null; }


        [JsonIgnore]
        public User User { get; set; } = null!;

        public Guid UserId { get; set; }

    }
}
