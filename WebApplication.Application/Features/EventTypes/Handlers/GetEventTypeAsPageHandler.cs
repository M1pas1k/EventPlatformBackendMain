using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.EventTypes.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.EventTypes.Handlers
{
    public class GetEventTypeAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventTypeAsPageQuery, Page<EventTypeDto>>
    {
        public async Task<Page<EventTypeDto>> Handle(GetEventTypeAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventTypes.ProjectTo<EventTypeDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
