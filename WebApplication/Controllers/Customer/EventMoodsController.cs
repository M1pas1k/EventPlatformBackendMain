using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.Features.EventMoods.Queries;
using WebApplication.Application.Pagination;

namespace WebApplication.API.Controllers.Customer
{
    [Tags("Events")]
    [Authorize]
    [ApiController]
    [Route("/api/events/moods")]
    public class EventMoodsController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetEventMoodByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventMoodsAsPageQuery() { Page = page }));
        }
    }
}
