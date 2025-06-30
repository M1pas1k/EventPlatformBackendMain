using MediatR;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Features.Tickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class GetTicketsHandler(IActions actions) : IRequestHandler<GetTicketsQuery, ICollection<TicketDto>>
    {
        public async Task<ICollection<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Ticket, TicketDto>(cancellationToken);
        }
    }
}
