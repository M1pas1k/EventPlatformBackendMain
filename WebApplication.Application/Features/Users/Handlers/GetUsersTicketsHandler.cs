using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.DTOs.UserTickets;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Users.Handlers
{
    public class GetUsersTicketsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersTicketsQuery, ICollection<UserTicketDto>>
    {
        public async Task<ICollection<UserTicketDto>> Handle(GetUsersTicketsQuery request, CancellationToken cancellationToken)
        {
            return await context.UsersTickets
                .AsNoTracking()
                .Where(ut => ut.UserId == request.UserId)
                .ProjectTo<UserTicketDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
