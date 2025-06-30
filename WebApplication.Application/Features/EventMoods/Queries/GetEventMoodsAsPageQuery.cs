using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.EventMoods.Queries
{
    public class GetEventMoodsAsPageQuery : IRequest<Page<EventMoodDto>>, ICacheable
    {
        public Pageable? Page { get; set; }
        public string CacheKey => $"event_moods:page:{Page.Index},{Page.Size}";
    }
}
