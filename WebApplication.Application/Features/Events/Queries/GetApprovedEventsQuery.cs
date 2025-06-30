using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Events.Queries
{
    public class GetApprovedEventsQuery : IRequest<Page<EventDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"events:page:{Page.Index},{Page.Size}:approved";
    }
}
