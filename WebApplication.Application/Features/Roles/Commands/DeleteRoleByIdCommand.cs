using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Roles.Commands
{
    public class DeleteRoleByIdCommand : IRequest<Result>, ICacheInvalidate
    {

        public Guid Id { get; set; }
        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
