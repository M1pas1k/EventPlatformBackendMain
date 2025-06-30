using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;

namespace WebApplication.Application.Features.EventMoods.Queries
{
    public class GetEventMoodByIdQuery : IRequest<Result<EventMoodDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"event_mood:{Id}";
    }
}
