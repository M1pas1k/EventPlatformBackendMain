using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Features.EventMoods.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventMoods.Handlers
{
    public class UpdateEventMoodByIdHandler(IActions actions) : IRequestHandler<UpdateEventMoodByIdCommand, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(UpdateEventMoodByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<EventMood, EventMoodDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
