using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;

namespace WebApplication.Application.Features.EventTypes.Commands
{
    public class CreateEventTypeCommand : IRequest<Result<EventTypeDto>>, ICacheInvalidate
    {
        public EventTypeCreateDto? Entity { get; set; }

        public string[] CacheKeys => ["eventTypes*"];
    }
}
