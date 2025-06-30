using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class UpdateRoleByIdHandler(IActions actions) : IRequestHandler<UpdateRoleByIdCommand, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Role, RoleDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
