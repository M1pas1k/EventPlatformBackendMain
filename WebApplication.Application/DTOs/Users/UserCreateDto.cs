using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;


namespace WebApplication.Application.DTOs.Users
{
    public class UserCreateDto : IMapWith<User>
    {
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public string ConfirmationCode { get; set; } = string.Empty;

        public ICollection<Guid> RoleIds { get; set; } = [];

    }
}
