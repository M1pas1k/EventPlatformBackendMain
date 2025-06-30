using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.EventMoods;
using WebApplication.Application.Features.EventMoods.Commands;
using WebApplication.Application.Features.EventMoods.Queries;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/events/moods")]
    public class EventMoodsController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventMoodsQuery(), ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventMoodCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateEventMoodCommand() { Entity = enity }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EventMoodUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateEventMoodByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteEventMoodByIdCommand() { Id = id }, ct));
        }
    }
}
