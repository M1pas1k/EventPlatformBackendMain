using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.UserTickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class GetUserTicketByIdHandler(IActions actions) : IRequestHandler<GetUserTicketByIdQuery, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(GetUserTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<UserTicket, UserTicketDto>(request.Id, cancellationToken);
        }
    }
}
