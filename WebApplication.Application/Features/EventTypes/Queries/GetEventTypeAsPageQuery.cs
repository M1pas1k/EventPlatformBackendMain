using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.EventTypes.Queries
{
    public class GetEventTypeAsPageQuery : IRequest<Page<EventTypeDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"event_types:page:{Page.Index},{Page.Size}";
    }
}
