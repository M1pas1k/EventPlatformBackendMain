using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Features.Tags.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class UpdateTagByIdHandler(IActions actions) : IRequestHandler<UpdateTagByIdCommand, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(UpdateTagByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Tag, TagDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
