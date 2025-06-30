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
    public class GetApprovedEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetApprovedEventsQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetApprovedEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Status == EventStatus.Approved)
                .OrderBy(e => e.StartAt)
                .PaginateAsync<Event, EventDto>
                (request.Page, mapper, cancellationToken);
        }
    }
}
