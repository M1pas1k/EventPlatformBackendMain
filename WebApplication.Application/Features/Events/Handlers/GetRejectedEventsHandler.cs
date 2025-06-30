using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class GetRejectedEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetRejectedEventsQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetRejectedEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Status == EventStatus.Rejected)
                .OrderBy(e => e.StartAt)
                .PaginateAsync<Event, EventDto>(request.Page, mapper, cancellationToken);
        }
    }
}
