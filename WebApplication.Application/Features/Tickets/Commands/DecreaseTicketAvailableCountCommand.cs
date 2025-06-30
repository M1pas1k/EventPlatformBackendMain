using MediatR;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Results;

namespace WebApplication.Application.Features.Tickets.Commands
{
    public class DecreaseTicketAvailableCountCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"ticket:{Id},", "tickets*"];
    }
}
