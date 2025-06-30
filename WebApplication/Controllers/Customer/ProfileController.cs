using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.API.Common;
using WebApplication.API.Extensions;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Auth.Handlers;
using WebApplication.Application.Features.Purchases.Queries;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Features.Users.Queries;
using WebApplication.Application.Pagination;
using WebApplication.Domain.Entities;

namespace WebApplication.API.Controllers.Customer
{
    [Authorize]
    [Tags("Users")]
    [ApiController]
    [Route("/api/users/profile")]
    public class ProfileController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProfile(CancellationToken ct)
        {
            // Профиль пользователя: email, name, birthdate, avatar, phonenumber, edit_date,
            return ToActionResult(await mediator.Send(new GetUserByIdQuery() { Id = User.Id() }, ct));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProfiel(string confirmationCode, CancellationToken ct)
        {
            var identity = (await mediator.Send(new GetIdentityByIdQuery() { Id = User.Id() }, ct)).Value!;
            var confirm = await mediator.Send(new VerifyConfirmationCodeCommand() { Email = identity.Email, Code = confirmationCode }, ct);
            if (confirm.IsFailure) return ToActionResult(confirm);

            return ToActionResult(await mediator.Send(new DeleteUserByIdCommand() { Id = User.Id() }, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UserUpdateDto user, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateUserCommand() { Id = User.Id(), User = user }, ct));
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersEventsQuery() { UserId = User.Id() }));
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersTicketsQuery() { UserId = User.Id() }));
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersNotificationsQuery() { UserId = User.Id() }));
        }

        [HttpGet("purchases")]
        public async Task<IActionResult> GetPurchases([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetPurchasesAsPageQuery() { UserId = User.Id(), Page = page }));
        }
    }
}
