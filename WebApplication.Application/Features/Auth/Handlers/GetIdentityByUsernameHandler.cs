using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Auth.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Auth.Handlers
{
    public class GetIdentityByUsernameHandler(IActions actions) : IRequestHandler<GetIdentityByUsernameQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetBy<User, UserIdentity>(user => user.Name, request.Username, cancellationToken);
        }
    }
}
