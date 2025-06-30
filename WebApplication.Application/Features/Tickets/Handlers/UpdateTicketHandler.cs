using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Features.Tickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class UpdateTicketHandler(IActions actions) : IRequestHandler<UpdateTicketCommand, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Ticket, TicketDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
