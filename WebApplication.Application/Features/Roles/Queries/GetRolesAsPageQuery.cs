using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Roles.Queries
{
    public class GetRolesAsPageQuery : IRequest<Page<RoleDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"roles:page:{Page.Index},{Page.Size}";
    }
}
