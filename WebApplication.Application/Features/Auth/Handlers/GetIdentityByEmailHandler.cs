using MediatR;
using WebApplication.Domain.Entities;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Auth.Queries;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Auth.Handlers
{
    public class GetIdentityByEmailHandler(IActions actions) : IRequestHandler<GetIdentityByEmailQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByEmailQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetBy<User, UserIdentity>(user => user.Email, request.Email, cancellationToken);
        }
    }
}
