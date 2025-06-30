using MediatR;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Features.EventMoods.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.EventMoods.Handlers
{
    public class GetEventMoodsHandler(IActions actions) : IRequestHandler<GetEventMoodsQuery, ICollection<EventMoodDto>>
    {
        public async Task<ICollection<EventMoodDto>> Handle(GetEventMoodsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<EventMood, EventMoodDto>(cancellationToken);
        }
    }
}
