using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;

namespace WebApplication.Application.Features.Events.Queries
{
    public class GetEventByIdQuery : IRequest<Result<EventDetailDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"event:{Id}";
    }
}
