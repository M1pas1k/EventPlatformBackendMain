using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Extentions;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUserAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersAsPageQuery, Page<UserDto>>
    {
        public async Task<Page<UserDto>> Handle(GetUsersAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Users.ProjectTo<UserDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
