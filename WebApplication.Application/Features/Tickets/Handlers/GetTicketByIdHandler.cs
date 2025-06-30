using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Features.Tickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class GetTicketByIdHandler(IActions actions) : IRequestHandler<GetTicketByIdQuery, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Ticket, TicketDto>(request.Id, cancellationToken);
        }
    }
}
