using MediatR;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.UserTickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class GetUserTicketsHandler(IActions actions) : IRequestHandler<GetUserTicketsQuery, ICollection<UserTicketDto>>
    {
        public async Task<ICollection<UserTicketDto>> Handle(GetUserTicketsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<UserTicket, UserTicketDto>(cancellationToken);
        }
    }
}
