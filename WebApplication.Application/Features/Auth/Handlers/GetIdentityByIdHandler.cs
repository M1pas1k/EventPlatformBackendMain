using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Auth.Handlers
{
    public class GetIdentityByIdQuery : IRequest<Result<UserIdentity>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"user:{Id}:identity";
    }
}
