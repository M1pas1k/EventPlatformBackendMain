using MediatR;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUsersHandler(IActions actions) : IRequestHandler<GetUsersQuery, ICollection<UserDto>>
    {
        public async Task<ICollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<User, UserDto>(cancellationToken);
        }
    }
}
