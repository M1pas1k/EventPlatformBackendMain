using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;

namespace WebApplication.Application.Features.Tickets.Commands
{
    public class CreateTicketCommand : IRequest<Result<TicketDto>>, ICacheInvalidate
    {
        public Guid EventId { get; set; }

        public TicketCreateDto Entity { get; set; }
        public string[] CacheKeys => ["tickets*", $"event:{EventId}"];
    }
}
