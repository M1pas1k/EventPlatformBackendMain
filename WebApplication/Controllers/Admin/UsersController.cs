using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Pagination;

namespace WebApplication.API.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/users")]
    public class UsersController(IMediator mediator, IEmailSender emailSender, IJobScheduler jobScheduler, IRandomCodeGeneration codeGenerator) : ControllerApiBase
    {
        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersAsPageQuery() { Page = page }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetUserByIdQuery() { Id = id }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteUserByIdCommand() { Id = id }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateDto user, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateUserCommand() { Id = id, User = user }, ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateUserCommand() { Entity = enity }, ct));
        }
    }
}
