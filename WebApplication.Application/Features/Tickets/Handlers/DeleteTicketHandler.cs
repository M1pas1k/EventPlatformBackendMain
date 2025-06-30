using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Tickets.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class DeleteTicketHandler(IActions actions) : IRequestHandler<DeleteTicketCommand, Result>
    {
        public async Task<Result> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Ticket>(request.Id, cancellationToken);
        }
    }
}
