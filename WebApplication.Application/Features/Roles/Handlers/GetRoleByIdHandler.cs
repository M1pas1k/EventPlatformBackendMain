using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class GetRoleByIdHandler(IActions actions) : IRequestHandler<GetRoleByIdQuery, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Role, RoleDto>(request.Id, cancellationToken);
        }
    }
}
