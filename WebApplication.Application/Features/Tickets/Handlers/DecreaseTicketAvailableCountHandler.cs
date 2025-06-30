using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Tickets.Commands;
using WebApplication.Application.Interfaces;

namespace WebApplication.Application.Features.Tickets.Handlers
{
    public class DecreaseTicketAvailableCountHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<DecreaseTicketAvailableCountCommand, Result>
    {
        public async Task<Result> Handle(DecreaseTicketAvailableCountCommand request, CancellationToken cancellationToken)
        {
            var updatesCount = await context.Tickets
                .Where(t => t.Id == request.Id)
                .ExecuteUpdateAsync(p => p.SetProperty(t => t.AvailableCount, t => t.AvailableCount - 1), cancellationToken);

            return updatesCount == 0 ? Result.Failure() : Result.Success();
        }
    }
}
