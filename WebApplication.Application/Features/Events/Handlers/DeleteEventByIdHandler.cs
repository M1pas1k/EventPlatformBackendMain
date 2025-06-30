using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Events.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class DeleteEventByIdHandler(IActions actions) : IRequestHandler<DeleteEventByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Event>(request.Id, cancellationToken);
        }
    }
}
