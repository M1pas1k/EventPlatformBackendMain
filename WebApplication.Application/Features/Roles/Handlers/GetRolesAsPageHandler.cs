using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Roles.Handlers
{
    public class GetRolesAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetRolesAsPageQuery, Page<RoleDto>>
    {
        public async Task<Page<RoleDto>> Handle(GetRolesAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Roles.ProjectTo<RoleDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
