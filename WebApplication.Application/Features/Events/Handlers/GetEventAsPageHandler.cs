using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Events;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class GetEventAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventAsPageQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetEventAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Events.ProjectTo<EventDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
