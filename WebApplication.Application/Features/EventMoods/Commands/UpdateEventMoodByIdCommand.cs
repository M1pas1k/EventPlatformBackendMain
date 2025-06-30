using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;

namespace WebApplication.Application.Features.EventMoods.Commands
{
    public class UpdateEventMoodByIdCommand : IRequest<Result<EventMoodDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventMoodUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"event_mood:{Id}", "event_moods*"];
    }
}
