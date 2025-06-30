using MediatR;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class GetEventsHandler(IActions actions) : IRequestHandler<GetEventsQuery, ICollection<EventDto>>
    {
        public async Task<ICollection<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Event, EventDto>(cancellationToken);
        }
    }
}
