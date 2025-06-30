using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.UserTickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class UpdateUserTicketHandler(IActions actions) : IRequestHandler<UpdateUserTicketCommand, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(UpdateUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<UserTicket, UserTicketDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
