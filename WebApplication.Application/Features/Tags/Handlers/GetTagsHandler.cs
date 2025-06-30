using MediatR;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Features.Tags.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class GetTagsHandler(IActions actions) : IRequestHandler<GetTagsQuery, ICollection<TagDto>>
    {
        public async Task<ICollection<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Tag, TagDto>(cancellationToken);
        }
    }
}
