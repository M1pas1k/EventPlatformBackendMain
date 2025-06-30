using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Features.EventMoods.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventMoods.Handlers
{
    public class CreateEventMoodHandler(IActions actions) : IRequestHandler<CreateEventMoodCommand, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(CreateEventMoodCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<EventMood, EventMoodDto>(request.Entity, cancellationToken);
        }
    }
}
