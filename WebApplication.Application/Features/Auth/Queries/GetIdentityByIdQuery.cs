using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Auth.Handlers;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Features.Auth.Queries
{
    public class GetIdentityByIdHandler(IActions actions) : IRequestHandler<GetIdentityByIdQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<User, UserIdentity>(request.Id, cancellationToken);
        }
    }
}
