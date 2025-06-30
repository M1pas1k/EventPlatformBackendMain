using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Tags.Queries
{
    public class GetTagsAsPageQuery : IRequest<Page<TagDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"tags:page:{Page.Index},{Page.Size}";
    }
}
