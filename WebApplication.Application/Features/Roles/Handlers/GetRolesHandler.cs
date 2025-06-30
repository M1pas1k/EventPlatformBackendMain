using MediatR;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class GetRolesHandler(IActions actions) : IRequestHandler<GetRolesQuery, ICollection<RoleDto>>
    {
        public async Task<ICollection<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Role, RoleDto>(cancellationToken);
        }
    }
}
