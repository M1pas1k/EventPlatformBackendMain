using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Roles.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class DeleteRoleByIdHandler(IActions actions) : IRequestHandler<DeleteRoleByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Role>(request.Id, cancellationToken);
        }
    }
}
