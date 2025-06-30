using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;

namespace WebApplication.Application.Features.UserTickets.Commands
{
    public class CreateUserTicketCommand : IRequest<Result<UserTicketDto>>, ICacheInvalidate
    {
        public UserTicketCreateDto Entity { get; set; }

        public string[] CacheKeys => ["user_tickets*"];
    }
}
