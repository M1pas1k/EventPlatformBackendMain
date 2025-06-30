using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.UserTickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class CreateUserTicketHandler(IActions actions) : IRequestHandler<CreateUserTicketCommand, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(CreateUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<UserTicket, UserTicketDto>(request.Entity, cancellationToken);
        }
    }
}
