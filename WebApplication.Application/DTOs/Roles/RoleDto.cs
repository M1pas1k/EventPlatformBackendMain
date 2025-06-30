using WebApplication.Application.Common.Mapping;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.DTOs.Roles
{
    public class RoleDto : IMapWith<Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isPublic { get; set; }
    }
}
