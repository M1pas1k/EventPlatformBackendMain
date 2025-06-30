using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.EventTypes.Commands
{
    public class DeleteEventTypeByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public string[] CacheKeys => [$"eventType:{Id}", "eventTypes*"];
    }
}
