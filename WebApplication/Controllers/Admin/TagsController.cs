using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.Tags;
using WebApplication.Application.Features.Tags.Commands;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/tags")]
    public class TagsController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(TagCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateTagCommand() { Entity = enity }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TagUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateTagByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteTagByIdCommand() { Id = id }, ct));
        }
    }
}
