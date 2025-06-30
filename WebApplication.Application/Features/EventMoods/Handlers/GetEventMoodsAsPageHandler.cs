using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.EventMoods.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.EventMoods.Handlers
{
    public class GetEventMoodsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventMoodsAsPageQuery, Page<EventMoodDto>>
    {
        public async Task<Page<EventMoodDto>> Handle(GetEventMoodsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventMoods.ProjectTo<EventMoodDto>(mapper.ConfigurationProvider).AsQueryable().PaginateAsync(request.Page, cancellationToken);
        }
    }
}
