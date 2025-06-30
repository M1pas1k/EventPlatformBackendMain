using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;

namespace WebApplication.Application.Features.Roles.Commands
{
    public class CreateRoleCommand : IRequest<Result<RoleDto>>, ICacheInvalidate
    {
        public RoleCreateDto Entity { get; set; }
        public string[] CacheKeys => ["roles*"];
    }
}
