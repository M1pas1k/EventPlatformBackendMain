using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Events.Commands
{
    public class ApproveEventCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid EventId { get; set; }
        public string[] CacheKeys => [$"event:{EventId}", $"events*"];
    }
}
