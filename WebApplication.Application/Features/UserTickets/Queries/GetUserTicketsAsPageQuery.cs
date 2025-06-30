using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.UserTickets.Queries
{
    public class GetUserTicketsAsPageQuery : IRequest<Page<UserTicketDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"user_tickets:page:{Page.Index},{Page.Size}";
    }
}
