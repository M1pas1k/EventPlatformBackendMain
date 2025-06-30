using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.DTOs.Users;

namespace WebApplication.Application.Features.Users.Queries
{
    public class GetUsersEventsQuery : IRequest<ICollection<UserEventDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:events";
    }
}
