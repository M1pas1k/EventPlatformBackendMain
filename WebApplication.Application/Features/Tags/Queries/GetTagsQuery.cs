using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Tags;

namespace WebApplication.Application.Features.Tags.Queries
{
    public class GetTagsQuery : IRequest<ICollection<TagDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
