using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Features.EventTypes.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class UpdateEventTypeByIdHandler(IActions actions) : IRequestHandler<UpdateEventTypeByIdCommand, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(UpdateEventTypeByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<EventType, EventTypeDto>(request.Id, request.Entity);
        }
    }
}
