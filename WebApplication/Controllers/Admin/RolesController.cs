using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.Roles;
using WebApplication.Application.Features.Roles.Commands;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Pagination;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/roles")]
    public class RolesController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetRolesQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetRoleByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetRolesAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateRoleCommand() { Entity = enity }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RoleUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateRoleByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteRoleByIdCommand() { Id = id }, ct));
        }

    }
}
