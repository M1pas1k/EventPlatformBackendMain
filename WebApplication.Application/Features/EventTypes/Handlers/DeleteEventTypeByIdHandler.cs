using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.EventTypes.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class DeleteEventTypeByIdHandler(IActions actions) : IRequestHandler<DeleteEventTypeByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventTypeByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<EventType>(request.Id, cancellationToken);
        }
    }
}
