using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Features.EventTypes.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class GetEventTypeByIdHandler(IActions actions) : IRequestHandler<GetEventTypeByIdQuery, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(GetEventTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<EventType, EventTypeDto>(request.Id, cancellationToken);
        }
    }
}
