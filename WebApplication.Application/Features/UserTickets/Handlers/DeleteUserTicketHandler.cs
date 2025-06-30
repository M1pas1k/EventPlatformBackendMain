using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.UserTickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.UserTickets.Handlers
{
    public class DeleteUserTicketHandler(IActions actions) : IRequestHandler<DeleteUserTicketCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<UserTicket>(request.Id, cancellationToken);
        }
    }
}
