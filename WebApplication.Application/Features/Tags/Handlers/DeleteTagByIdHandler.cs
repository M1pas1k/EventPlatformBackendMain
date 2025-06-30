using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Tags.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Tags.Handlers
{
    public class DeleteTagByIdHandler(IActions actions) : IRequestHandler<DeleteTagByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteTagByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Tag>(request.Id, cancellationToken);
        }
    }
}
