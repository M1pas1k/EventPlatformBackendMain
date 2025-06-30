using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Roles
{
    public class RoleUpdateDto : IMapWith<Role>
    {
        public string? Name { get; set; }
        public bool? isPublic { get; set; }
    }
}
