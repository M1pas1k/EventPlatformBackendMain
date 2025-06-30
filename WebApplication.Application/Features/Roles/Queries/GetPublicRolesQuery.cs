using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Roles;

namespace WebApplication.Application.Features.Roles.Queries
{
    public class GetPublicRolesQuery : IRequest<ICollection<RoleDto>>, ICacheable
    {
        public string CacheKey => $"roles:public";
    }
}
