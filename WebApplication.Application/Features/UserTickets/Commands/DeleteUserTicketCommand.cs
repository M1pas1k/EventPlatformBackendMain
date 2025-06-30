using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.UserTickets.Commands
{
    public class DeleteUserTicketCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"user_ticket:{Id}", "user_tickets*"];
    }
}
