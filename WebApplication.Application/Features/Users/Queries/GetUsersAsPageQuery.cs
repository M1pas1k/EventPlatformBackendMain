using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUsersAsPageQuery : IRequest<Page<UserDto>>, ICacheable
    {
        public Pageable Page { get; set; }

        public string CacheKey => $"users:page:{Page.Index},{Page.Size}";
    }
}
