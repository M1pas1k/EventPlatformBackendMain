using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApplication.Application.Common.Results;
using WebApplication.Application.Features.Events.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Enums;

namespace WebApplication.Application.Features.Events.Handlers
{
    public class ApproveEventHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<ApproveEventCommand, Result>
    {
        public async Task<Result> Handle(ApproveEventCommand request, CancellationToken cancellationToken)
        {
            var updated = await context.Events
               .Where(e => e.Id == request.EventId)
               .ExecuteUpdateAsync(p => p.SetProperty(e => e.Status, EventStatus.Approved), cancellationToken);

            return updated == 0 ? Result.Failure("Event not updated", Status.BadRequest) : Result.Success();
        }
    }
}
