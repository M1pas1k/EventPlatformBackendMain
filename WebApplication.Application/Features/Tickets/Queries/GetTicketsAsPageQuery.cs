using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Tickets.Queries
{
    public class GetTicketsAsPageQuery : IRequest<Page<TicketDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"tickets:page:{Page.Index},{Page.Size}";
    }
}
