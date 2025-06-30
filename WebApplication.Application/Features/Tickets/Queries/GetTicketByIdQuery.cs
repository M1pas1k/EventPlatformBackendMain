using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;

namespace WebApplication.Application.Features.Tickets.Queries
{
    public class GetTicketByIdQuery : IRequest<Result<TicketDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"ticket:{Id}";

    }
}
