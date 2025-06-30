using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUserByIdHandler(IActions actions) : IRequestHandler<GetUserByIdQuery, Result<UserDetailDto>>
    {
        public async Task<Result<UserDetailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<User, UserDetailDto>(request.Id, cancellationToken);
        }
    }
}
