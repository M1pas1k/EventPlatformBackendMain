using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Roles
{
    public class RoleCreateDto : IMapWith<Role>
    {
        public string Name { get; set; } = string.Empty;

        public bool isPublic { get; set; }
    }
}
