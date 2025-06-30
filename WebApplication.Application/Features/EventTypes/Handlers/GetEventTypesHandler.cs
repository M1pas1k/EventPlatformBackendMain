using MediatR;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Features.EventTypes.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class GetEventTypesHandler(IActions actions) : IRequestHandler<GetEventTypesQuery, ICollection<EventTypeDto>>
    {
        public async Task<ICollection<EventTypeDto>> Handle(GetEventTypesQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<EventType, EventTypeDto>(cancellationToken);
        }
    }
}
