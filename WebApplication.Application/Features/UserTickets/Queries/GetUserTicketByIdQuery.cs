using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;

namespace WebApplication.Application.Features.UserTickets.Queries
{
    public class GetUserTicketByIdQuery : IRequest<Result<UserTicketDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"user_ticket:{Id}";
    }
}
