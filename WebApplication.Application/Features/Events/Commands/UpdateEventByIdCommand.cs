using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;

namespace WebApplication.Application.Features.Events.Commands
{
    public class UpdateEventByIdCommand : IRequest<Result<EventDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventUpdateDto? Event { get; set; }

        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
