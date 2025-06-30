using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class CreateRoleHandler(IActions actions) : IRequestHandler<CreateRoleCommand, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Role, RoleDto>(request.Entity, cancellationToken);
        }
    }
}
