using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Features.Tags.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class GetTagByIdHandler(IActions actions) : IRequestHandler<GetTagByIdQuery, Result<TagDto>>
    {
        public async Task<Result<TagDto>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Tag, TagDto>(request.Id, cancellationToken);
        }
    }
}
