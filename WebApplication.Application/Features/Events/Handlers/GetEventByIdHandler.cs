using AutoMapper;
using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class GetEventByIdHandler(IActions actions, IMapper mapper) : IRequestHandler<GetEventByIdQuery, Result<EventDetailDto>>
    {
        public async Task<Result<EventDetailDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Event, EventDetailDto>(request.Id, cancellationToken);
        }
    }
}
