using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;

namespace WebApplication.Application.Features.Tags.Commands
{
    public class UpdateTagByIdCommand : IRequest<Result<TagDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public TagUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"tag:{Id}", "tags*"];
    }
}
