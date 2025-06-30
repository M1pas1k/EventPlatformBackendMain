using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;

namespace WebApplication.Application.Features.Tags.Commands
{
    public class CreateTagCommand : IRequest<Result<TagDto>>, ICacheInvalidate
    {
        public TagCreateDto Entity { get; set; }
        public string[] CacheKeys => ["tags*"];
    }
}
