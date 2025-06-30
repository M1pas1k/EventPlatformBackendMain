using MediatR;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Auth.Queries
{
    public class GetIdentityByUsernameQuery : IRequest<Result<UserIdentity>>
    {
        public string? Username { get; set; }
    }
}
