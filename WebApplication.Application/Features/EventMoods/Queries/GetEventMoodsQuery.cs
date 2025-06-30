using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.EventMoods;

namespace WebApplication.Application.Features.EventMoods.Queries
{
    public class GetEventMoodsQuery : IRequest<ICollection<EventMoodDto>>, ICacheable
    {
        public string CacheKey => $"event_moods";
    }
}
