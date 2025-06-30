using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;

namespace WebApplication.Application.Features.EventTypes.Commands
{
    public class UpdateEventTypeByIdCommand : IRequest<Result<EventTypeDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventTypeUpdateDto? Entity { get; set; }

        public string[] CacheKeys => [$"eventType:{Id}", "eventTypes*"];
    }
}
