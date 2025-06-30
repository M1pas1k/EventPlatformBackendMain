using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Features.Tickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class CreateTicketHandler(IActions actions) : IRequestHandler<CreateTicketCommand, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Ticket, TicketDto>(request.Entity, cancellationToken, async (ticket, _) => ticket.EventId = request.EventId);
        }
    }
}
