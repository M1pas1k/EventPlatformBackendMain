using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.Features.Tickets.Queries;

namespace WebApplication.API.Controllers.Customer
{
    [Tags("Tickets")]
    [Authorize]
    [ApiController]
    [Route("/api/tickets")]
    public class TicketsReadController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetTicketByIdQuery() { Id = id }, ct));
        }
    }
}
