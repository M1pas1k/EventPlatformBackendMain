using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;

namespace WebApplication.Application.Features.EventTypes.Queries
{
    public class GetEventTypeByIdQuery : IRequest<Result<EventTypeDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"events:{Id}";
    }
}
