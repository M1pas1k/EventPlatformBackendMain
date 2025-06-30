using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;

namespace WebApplication.Application.Features.UserTickets.Commands
{
    public class UpdateUserTicketCommand : IRequest<Result<UserTicketDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public UserTicketUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"user_ticket:{Id}", "user_tickets*"];
    }
}
