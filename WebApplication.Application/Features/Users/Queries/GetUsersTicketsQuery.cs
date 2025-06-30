using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.UserTickets;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUsersTicketsQuery : IRequest<ICollection<UserTicketDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:tickets";
    }
}
