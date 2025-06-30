using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;

namespace WebApplication.Application.Features.Events.Commands
{
    public class CreateEventCommand : IRequest<Result<EventDto>>, ICacheInvalidate
    {
        public EventCreateDto? Entity { get; set; }

        public string[] CacheKeys => ["events*"];
    }
}
