using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Features.EventTypes.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class CreateEventTypeHandler(IActions actions) : IRequestHandler<CreateEventTypeCommand, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<EventType, EventTypeDto>(request.Entity, cancellationToken);
        }
    }
}
