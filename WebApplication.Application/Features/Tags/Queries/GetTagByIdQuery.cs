using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;

namespace WebApplication.Application.Features.Tags.Queries
{
    public class GetTagByIdQuery : IRequest<Result<TagDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"tag:{Id}";
    }
}
