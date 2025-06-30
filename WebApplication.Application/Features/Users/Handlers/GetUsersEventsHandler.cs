using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUsersEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersEventsQuery, ICollection<UserEventDto>>
    {
        public async Task<ICollection<UserEventDto>> Handle(GetUsersEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsNoTracking()
                .Where(e => e.CreatorId == request.UserId)
                .ProjectTo<UserEventDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
