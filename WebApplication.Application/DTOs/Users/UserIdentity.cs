using WebApplication.Application.Common.Mapping;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Users
{
    public class UserIdentity : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime PasswordUpdatedAt { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = [];
    }
}
