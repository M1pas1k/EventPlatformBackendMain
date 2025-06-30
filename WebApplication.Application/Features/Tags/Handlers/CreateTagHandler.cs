using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Features.Tags.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class CreateTagHandler(IActions actions) : IRequestHandler<CreateTagCommand, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Tag, TagDto>(request.Entity, cancellationToken);
        }
    }
}
