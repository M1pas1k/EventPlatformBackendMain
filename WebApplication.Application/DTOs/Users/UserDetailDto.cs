using WebApplication.Application.Common.Mapping;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Domain.Entities;


namespace WebApplication.Application.DTOs.Users
{
    public class UserDetailDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<RoleDto> Roles { get; set; } = [];

    }
}
