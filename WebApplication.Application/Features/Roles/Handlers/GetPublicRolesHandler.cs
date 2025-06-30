using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class GetPublicRolesHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetPublicRolesQuery, ICollection<RoleDto>>
    {
        public async Task<ICollection<RoleDto>> Handle(GetPublicRolesQuery request, CancellationToken cancellationToken)
        {
            return await context.Roles
                .Where(r => r.isPublic)
                .ProjectTo<RoleDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
