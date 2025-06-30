using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.EventTypes;
using WebApplication.Application.Features.EventTypes.Commands;
using WebApplication.Application.Features.EventTypes.Queries;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/events/types")]
    public class EventTypesController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventTypesQuery(), ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventTypeCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateEventTypeCommand() { Entity = enity }, ct));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EventTypeUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateEventTypeByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteEventTypeByIdCommand() { Id = id }, ct));
        }

    }
}
