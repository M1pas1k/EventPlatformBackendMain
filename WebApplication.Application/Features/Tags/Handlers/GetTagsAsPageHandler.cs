using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Tags.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class GetTagsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTagsAsPageQuery, Page<TagDto>>
    {
        public async Task<Page<TagDto>> Handle(GetTagsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventTags.ProjectTo<TagDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
