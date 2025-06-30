using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;

namespace WebApplication.Application.Features.Roles.Queries
{
    public class GetRoleByIdQuery : IRequest<Result<RoleDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"role:{Id}";
    }
}
