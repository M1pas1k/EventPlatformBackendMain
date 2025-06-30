using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Tickets;

namespace WebApplication.Application.Features.Tickets.Queries
{
    public class GetTicketsQuery : IRequest<ICollection<TicketDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
