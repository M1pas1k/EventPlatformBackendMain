using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.Features.Events.Queries;
using WebApplication.Application.Pagination;

namespace WebApplication.API.Controllers.Customer
{
    [Tags("Events")]
    [Authorize]
    [ApiController]
    [Route("/api/events")]
    public class EventsReadController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetEventByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetApprovedEventsQuery() { Page = page }));
        }
    }
}
