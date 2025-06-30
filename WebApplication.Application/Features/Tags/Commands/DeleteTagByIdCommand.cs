using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Tags.Commands
{
    public class DeleteTagByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"tag:{Id}", "tags*"];
    }
}
