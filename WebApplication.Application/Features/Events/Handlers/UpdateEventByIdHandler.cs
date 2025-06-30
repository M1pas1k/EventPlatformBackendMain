using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Features.Events.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class UpdateEventByIdHandler(IActions actions) : IRequestHandler<UpdateEventByIdCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(UpdateEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Event, EventDto>(request.Id, request.Event, cancellationToken,
                (event_) =>
                {
                    if (event_.StartAt - DateTime.UtcNow <= TimeSpan.FromDays(1))
                    {
                        throw new InvalidOperationException("Cant edit event starting in less then 24 hours");
                    }
                    event_.Status = EventStatus.UnderModeration;
                });
        }
    }
}
