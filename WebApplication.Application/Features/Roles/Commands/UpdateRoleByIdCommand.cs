using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;

namespace WebApplication.Application.Features.Roles.Commands
{
    public class UpdateRoleByIdCommand : IRequest<Result<RoleDto>>, ICacheInvalidate

    {
        public Guid Id { get; set; }

        public RoleUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"role:{Id}", "roles*"];
    }
}
