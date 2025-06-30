using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Result<UserDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public UserUpdateDto User { get; set; }

        public string[] CacheKeys => [$"user:{Id}", "users*"];
    }
}
