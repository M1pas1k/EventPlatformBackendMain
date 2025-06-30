using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;

namespace WebApplication.Application.Features.Tickets.Commands
{
    public class UpdateTicketCommand : IRequest<Result<TicketDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public TicketUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"ticket:{Id}", "tickets*"];
    }
}
