using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Tickets;
using WebApplication.Application.Features.Tickets.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class GetTicketIfAvailableHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTicketIfAvailableQuery, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(GetTicketIfAvailableQuery request, CancellationToken cancellationToken)
        {
            var ticket = await context.Tickets
                .Where(t => t.Id == request.Id && t.Event.Status == EventStatus.Approved)
                .ProjectTo<TicketDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return ticket is null ? Result.Failure<TicketDto>("Ticket not available", Status.Forbiden)
                : Result.Success(ticket);
        }
    }
}
