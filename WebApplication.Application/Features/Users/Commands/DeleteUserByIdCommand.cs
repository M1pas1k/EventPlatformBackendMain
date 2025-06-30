using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Users.Commands
{
    public class DeleteUserByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public string[] CacheKeys => ["users*"];
    }
}
