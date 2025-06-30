using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUserByIdQuery : IRequest<Result<UserDetailDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"users:{Id}";
    }
}
