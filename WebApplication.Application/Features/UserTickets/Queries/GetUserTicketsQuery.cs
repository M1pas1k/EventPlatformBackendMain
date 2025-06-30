using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.UserTickets;

namespace WebApplication.Application.Features.UserTickets.Queries
{
    public class GetUserTicketsQuery : IRequest<ICollection<UserTicketDto>>, ICacheable
    {
        public string CacheKey => $"user_tickets";
    }
}
