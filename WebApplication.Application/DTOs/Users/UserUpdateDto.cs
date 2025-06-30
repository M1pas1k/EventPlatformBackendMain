using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Users
{
    public class UserUpdateDto : IMapWith<User>
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
