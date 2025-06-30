using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.EventTypes;

namespace WebApplication.Application.Features.EventTypes.Queries
{
    public class GetEventTypesQuery : IRequest<ICollection<EventTypeDto>>, ICacheable
    {
        public string CacheKey => $"eventTypes";
    }
}
