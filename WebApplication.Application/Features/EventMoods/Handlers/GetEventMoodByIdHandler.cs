using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Features.EventMoods.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventMoods.Handlers
{
    public class GetEventMoodByIdHandler(IActions actions) : IRequestHandler<GetEventMoodByIdQuery, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(GetEventMoodByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<EventMood, EventMoodDto>(request.Id, cancellationToken);
        }
    }
}
