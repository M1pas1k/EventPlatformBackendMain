using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Result<UserDto>>, ICacheInvalidate
    {
        public UserCreateDto Entity { get; set; }

        public string[] CacheKeys => ["users*"];
    }
}
