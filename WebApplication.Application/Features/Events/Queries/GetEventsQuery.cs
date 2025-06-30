using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Events;

namespace WebApplication.Application.Features.Events.Queries
{
    public class GetEventsQuery : IRequest<ICollection<EventDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
