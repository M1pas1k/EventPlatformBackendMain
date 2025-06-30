using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>, ICacheable
    {
        public string CacheKey => $"users";
    }
}
