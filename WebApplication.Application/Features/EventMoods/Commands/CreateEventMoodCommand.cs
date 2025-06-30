using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;

namespace WebApplication.Application.Features.EventMoods.Commands
{
    public class CreateEventMoodCommand : IRequest<Result<EventMoodDto>>, ICacheInvalidate
    {
        public EventMoodCreateDto? Entity { get; set; }
        public string[] CacheKeys => ["event_moods*"];
    }
}
